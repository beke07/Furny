using AutoMapper;
using Furny.Common.Enums;
using Furny.Common.Filters;
using Furny.Common.Services;
using Furny.FurnitureFeature.Commands;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.NotificationFeature.Commands;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ServiceInterfaces;
using Furny.OfferFeature.ViewModels;
using Furny.OrderFeature.Commands;
using Furny.OrderFeature.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Furny.OfferFeature.Services
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private const string collectionName = "offers";
        private const int _mm2Tom2 = 1000000;
        private const int _mmToM = 1000;
        private const int _tableWidth = 2080;
        private const int _tableHeight = 2070;

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OfferService(
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task CreateAsnyc(OfferFeatureOfferDto offerDto, string designerId, string furnitureId)
        {
            var componentsByPanelCutters = offerDto.Components.GroupBy(e => e.PanelCutterId);
            foreach (var components in componentsByPanelCutters.Select(e => e.ToList()))
            {
                components.ForEach(e =>
                {
                    e.DesignerId = designerId;
                    e.FurnitureId = furnitureId;
                });

                var offer = new Offer()
                {
                    PanelCutterId = components.First().PanelCutterId,
                    DesignerId = designerId,
                    FurnitureId = furnitureId,
                    State = OfferState.Created,
                    Components = _mapper.Map<IList<OfferComponent>>(components)
                };

                await _collection.InsertOneAsync(offer);
            }

            var panelCutters = componentsByPanelCutters.Select(e => e.Key);

            foreach (var panelCutter in panelCutters)
            {
                await _mediator.Send(NotificationFeatureCreateNotificationCommand.Create(panelCutter, new Notification()
                {
                    Link = "panelcutter-offers",
                    Text = "Árajánlati kérelem érkezett!"
                }));
            }
        }

        public async Task<IList<OfferFeatureOfferDto>> GetDesignerOffersAsnyc(string designerId, string furnitureId)
        {
            var offers = (await Get()).Where(e => e.DesignerId == designerId && e.FurnitureId == furnitureId);

            var result = new List<OfferFeatureOfferDto>();
            foreach (var offer in offers)
            {
                var offerDto = new OfferFeatureOfferDto()
                {
                    Id = offer.Id.ToString(),
                    State = offer.State,
                    Deadline = offer.Deadline,
                    Price = offer.Price,
                    Components = _mapper.Map<IList<OfferFeatureOfferComponentDto>>(offer.Components)
                };

                foreach (var component in offerDto.Components)
                {
                    component.PanelCutterId = offer.PanelCutterId;
                }

                result.Add(offerDto);
            }

            return result;
        }

        public async Task<List<OfferFeatureDesignerOfferTableViewModel>> GetDesignerOfferTableAsnyc(string designerId)
        {
            var offers = (await Get()).Where(e => e.DesignerId == designerId);

            var result = new List<OfferFeatureDesignerOfferTableViewModel>();
            foreach (var offer in offers)
            {
                var furniture = await _mediator.Send(FurnitureGetFurnitureCommand.Create(designerId, offer.FurnitureId));

                result.Add(new OfferFeatureDesignerOfferTableViewModel()
                {
                    Id = offer.Id.ToString(),
                    CreatedOn = offer.Id.CreationTime,
                    FurnitureId = furniture.Id,
                    FurnitureName = furniture.Name,
                    State = offer.State
                });
            }

            return result;
        }

        public async Task<OfferFeaturePanelCutterOfferDto> GetPanelCutterOfferAsync(string offerId)
        {
            var offer = await FindByIdAsync(offerId);

            var offerDto = new OfferFeaturePanelCutterOfferDto()
            {
                Offer = _mapper.Map<OfferFeatureOfferDto>(offer)
            };

            long countedPrice = 0;
            foreach (var components in offer.Components.GroupBy(c => c.Material.Id).Select(c => c.ToList()))
            {
                var material = components.First().Material;

                if (material.Type == MaterialType.M2)
                {
                    var quantity = components.Sum(e => e.Component.Height * e.Component.Width) / _mm2Tom2;
                    countedPrice += (long)Math.Ceiling(material.Price * quantity);
                    offerDto.MaterialQuantity.Add($"{material.Name} ({material.Price} Ft/m²)", $"{quantity} m²");
                }
                else if (material.Type == MaterialType.Table)
                {
                    var quantity = (long)Math.Ceiling(components.Sum(e => e.Component.Height * e.Component.Width) / (_tableWidth * _tableHeight));
                    countedPrice += material.Price * quantity;
                    offerDto.MaterialQuantity.Add($"{material.Name} ({material.Price} Ft/tábla)", $"{quantity} tábla");
                }
            }

            foreach (var components in offer.Components.GroupBy(c => c.Closing.Id).Select(c => c.ToList()))
            {
                var closing = components.First().Closing;
                var component = components.First().Component;

                double closingLengthInMM = 0;

                if (component.Closings.Top) closingLengthInMM += component.Width;
                if (component.Closings.Bottom) closingLengthInMM += component.Width;
                if (component.Closings.Left) closingLengthInMM += component.Height;
                if (component.Closings.Right) closingLengthInMM += component.Height;

                var closingLengthInMeter = closingLengthInMM / _mmToM;
                countedPrice += (long)closingLengthInMeter * closing.Price;

                offerDto.ClosingQuantity.Add($"{closing.Name} ({closing.Price} Ft/m)", $"{closingLengthInMeter} m");
            }

            offerDto.CountedPrice = countedPrice;
            return offerDto;
        }

        public async Task<IList<OfferFeaturePanelCutterOfferTableViewModel>> GetPanelCutterOfferTableAsync(string panelCutterId)
        {
            var offers = (await Get()).Where(e => e.PanelCutterId == panelCutterId).ToList();

            var result = new List<OfferFeaturePanelCutterOfferTableViewModel>();
            foreach (var offer in offers)
            {
                result.Add(new OfferFeaturePanelCutterOfferTableViewModel()
                {
                    Id = offer.Id.ToString(),
                    CreatedOn = offer.Id.CreationTime,
                    State = offer.State,
                    DesignerName = (await _mediator.Send(GetDesignerCommand.Create(offer.DesignerId))).Name
                });
            }

            return result;
        }

        public async Task FillPanelCutterOfferAsync(OfferFeaturePanelCutterFillOfferDto offerDto, string offerId)
        {
            var offer = await FindByIdAsync(offerId);

            if (offer.State == OfferState.Done)
            {
                throw new HttpResponseException("Az árajánlat már ki van töltve!", HttpStatusCode.BadRequest);
            }

            offer.Deadline = offerDto.Deadline;
            offer.Price = offerDto.Price;
            offer.State = OfferState.Done;

            await UpdateAsync(offer);

            await _mediator.Send(NotificationFeatureCreateNotificationCommand.Create(offer.DesignerId, new Notification()
            {
                Text = "Árajánlat érkezett!",
                Link = "designer-offers"
            }));
        }

        public async Task AcceptAsnyc(string id, OrderFeatureOrderFillDto orderDto)
        {
            var offer = await FindByIdAsync(id);
            offer.State = OfferState.Accepted;

            await UpdateAsync(offer);

            var order = new Order()
            {
                Offer = offer
            };

            order.Delivery = orderDto.Delivery;
            order.Comment = orderDto.Comment;

            await _mediator.Send(new OrderFeatureCreateOrderCommand(offer));

            await _mediator.Send(NotificationFeatureCreateNotificationCommand.Create(offer.PanelCutterId, new Notification()
            {
                Text = "A megrendelő elfogadta az árajánlatot, megrendelés érkezett!",
                Link = "accept-offer"
            }));
        }

        public async Task DeclineAsnyc(string id)
        {
            var offer = await FindByIdAsync(id);
            offer.State = OfferState.Declined;

            await UpdateAsync(offer);

            await _mediator.Send(NotificationFeatureCreateNotificationCommand.Create(offer.PanelCutterId, new Notification()
            {
                Text = "A megrendelő elutasította az árajánlatot!",
                Link = "accept-offer"
            }));
        }
    }
}
