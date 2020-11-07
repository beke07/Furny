using AutoMapper;
using Furny.Common.Enums;
using Furny.Data;
using Furny.Filters;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private const string collectionName = "offers";
        private const int _mm2Tom2 = 1000000;
        private const int _tableWidth = 2080;
        private const int _tableHeight = 2070;
        private readonly IMapper _mapper;
        private readonly IFurnitureService _furnitureService;
        private readonly IDesignerService _designerService;
        private readonly IOrderService _orderService;
        private readonly INotificationService _notificationService;

        public OfferService(
            IMapper mapper,
            IFurnitureService furnitureService,
            IDesignerService designerService,
            IOrderService orderService,
            INotificationService notificationService,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _furnitureService = furnitureService;
            _designerService = designerService;
            _orderService = orderService;
            _notificationService = notificationService;
        }

        public async Task CreateAsnyc(OfferCommand offerDto, string desginerId, string furnitureId)
        {
            var componentsByPanelCuttes = offerDto.Components.GroupBy(e => e.PanelCutterId);
            foreach (var components in componentsByPanelCuttes.Select(e => e.ToList()))
            {
                components.ForEach(e =>
                {
                    e.DesignerId = desginerId;
                    e.FurnitureId = furnitureId;
                });

                var offer = new Offer()
                {
                    PanelCutterId = components.First().PanelCutterId,
                    DesginerId = desginerId,
                    FurnitureId = furnitureId,
                    Components = _mapper.Map<IList<OfferComponent>>(components)
                };

                await _collection.InsertOneAsync(offer);
            }

            var panelCutters = componentsByPanelCuttes.Select(e => e.Key);

            foreach (var panelCutter in panelCutters)
            {
                await _notificationService.CreateNotificationAsync(panelCutter, new Notification()
                {
                    Text = "Árajánlati kérelem érkezett!"
                });
            }
        }

        public async Task<IList<OfferCommand>> GetDesignerOffersAsnyc(string designerId, string furnitureId)
        {
            var offers = (await Get()).Where(e => e.DesginerId == designerId && e.FurnitureId == furnitureId);

            var result = new List<OfferCommand>();
            foreach (var offer in offers)
            {
                var offerDto = new OfferCommand()
                {
                    State = offer.State,
                    Deadline = offer.Deadline,
                    Price = offer.Price,
                    Components = _mapper.Map<IList<OfferComponentCommand>>(offer.Components)
                };

                foreach (var component in offerDto.Components)
                {
                    component.PanelCutterId = offer.PanelCutterId;
                }

                result.Add(offerDto);
            }

            return result;
        }

        public async Task<List<DesignerOfferTableCommand>> GetDesignerOfferTableAsnyc(string designerId, string furnitureId)
        {
            var offers = (await Get()).Where(e => e.DesginerId == designerId && e.FurnitureId == furnitureId);

            var furniture = await _furnitureService.GetByIdAsync(designerId, furnitureId);

            var result = new List<DesignerOfferTableCommand>();
            foreach (var offer in offers)
            {
                result.Add(new DesignerOfferTableCommand()
                {
                    _id = offer.Id.ToString(),
                    CreatedOn = offer.Id.CreationTime,
                    FurnitureName = furniture.Name,
                    State = offer.State
                });
            }

            return result;
        }

        public async Task<PanelCutterOfferCommand> GetPanelCutterOfferAsync(string offerId)
        {
            var offer = await FindByIdAsync(offerId);

            var offerDto = new PanelCutterOfferCommand()
            {
                Offer = _mapper.Map<OfferCommand>(offer)
            };

            long countedPrice = 0;
            foreach (var components in offer.Components.GroupBy(c => c.Material.Id).Select(c => c.ToList()))
            {
                var material = components.First().Material;

                if (material.Type == MaterialType.M2)
                {
                    var quantity = components.Sum(e => e.Component.Height * e.Component.Width) / _mm2Tom2;
                    countedPrice += (long)Math.Ceiling(material.Price * quantity);
                    offerDto.MaterialQuantity.Add(material.Name, $"{quantity} m²");
                }
                else if (material.Type == MaterialType.Table)
                {
                    var quantity = (long)Math.Ceiling(components.Sum(e => e.Component.Height * e.Component.Width) / (_tableWidth * _tableHeight));
                    countedPrice += material.Price * quantity;
                    offerDto.MaterialQuantity.Add(material.Name, $"{quantity} tábla");
                }
            }

            offerDto.CountedPrice = countedPrice;
            return offerDto;
        }

        public async Task<IList<PanelCutterOfferTabeCommand>> GetPanelCutterOfferTableAsync(string panelCutterId)
        {
            var offers = (await Get()).Where(e => e.PanelCutterId == panelCutterId).ToList();

            var result = new List<PanelCutterOfferTabeCommand>();
            foreach (var offer in offers)
            {
                result.Add(new PanelCutterOfferTabeCommand()
                {
                    _id = offer.Id.ToString(),
                    CreatedOn = offer.Id.CreationTime,
                    State = offer.State,
                    DesignerName = (await _designerService.FindByIdAsync(offer.DesginerId)).Name
                });
            }

            return result;
        }

        public async Task FillPanelCutterOfferAsync(PanelCutterFillOfferCommand offerDto, string offerId)
        {
            var offer = await FindByIdAsync(offerId);

            if (offer.State == OfferState.Done)
            {
                throw new HttpResponseException("Az árajánlat már ki van töltve!", HttpStatusCode.BadRequest);
            }

            offer.Deadline = offerDto.Deadline;
            offer.Price = offerDto.Price;

            await UpdateAsync(offer);

            await _orderService.CreateAsnyc(offer);

            await _notificationService.CreateNotificationAsync(offer.DesginerId, new Notification()
            {
                Text = "Árajánlat érkezett!"
            });
        }
    }
}
