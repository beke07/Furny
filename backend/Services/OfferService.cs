using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Furny.Common.Enums;

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

        public OfferService(
            IMapper mapper,
            IFurnitureService furnitureService,
            IDesignerService designerService,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
            _furnitureService = furnitureService;
            _designerService = designerService;
        }

        public async Task CreateAsnyc(OfferDto offerDto, string desginerId, string furnitureId)
        {
            foreach (var components in offerDto.Components.GroupBy(e => e.PanelCutterId).Select(e => e.ToList()))
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
        }

        public async Task<IList<OfferDto>> GetDesignerOffersAsnyc(string designerId, string furnitureId)
        {
            var offers = (await Get()).Where(e => e.DesginerId == designerId && e.FurnitureId == furnitureId);

            var result = new List<OfferDto>();
            foreach (var offer in offers)
            {
                var offerDto = new OfferDto()
                {
                    State = offer.State,
                    Deadline = offer.Deadline,
                    Price = offer.Price,
                    Components = _mapper.Map<IList<OfferComponentDto>>(offer.Components)
                };

                foreach (var component in offerDto.Components)
                {
                    component.PanelCutterId = offer.PanelCutterId;
                }

                result.Add(offerDto);
            }

            return result;
        }

        public async Task<List<DesignerOfferTableDto>> GetDesignerOfferTableAsnyc(string designerId, string furnitureId)
        {
            var offers = (await Get()).Where(e => e.DesginerId == designerId && e.FurnitureId == furnitureId);

            var furniture = await _furnitureService.GetByIdAsync(designerId, furnitureId);

            var result = new List<DesignerOfferTableDto>();
            foreach (var offer in offers)
            {
                result.Add(new DesignerOfferTableDto()
                {
                    FurnitureName = furniture.Name,
                    State = offer.State
                });
            }

            return result;
        }

        public async Task<PanelCutterOfferDto> GetPanelCutterOfferAsync(string offerId)
        {
            var offer = await FindByIdAsync(offerId);

            var offerDto = new PanelCutterOfferDto()
            {
                Offer = _mapper.Map<OfferDto>(offer)
            };

            long countedPrice = 0;
            foreach (var components in offer.Components.GroupBy(c => c.Material.Id).Select(c => c.ToList()))
            {
                var material = components.First().Material;

                if (material.Type == MaterialType.M2)
                {
                    var quantity = components.Sum(e => e.Component.Height * e.Component.Width) / _mm2Tom2;
                    countedPrice += (long)Math.Ceiling(material.Price * quantity);
                    offerDto.MaterialQuantity.Add(material.Name, quantity);
                }
                else if (material.Type == MaterialType.Table)
                {
                    var quantity = (long)Math.Ceiling(components.Sum(e => e.Component.Height * e.Component.Width) / (_tableWidth * _tableHeight));
                    countedPrice += material.Price * quantity;
                    offerDto.MaterialQuantity.Add(material.Name, quantity);
                }
            }

            offerDto.CountedPrice = countedPrice;
            return offerDto;
        }

        public async Task<IList<PanelCutterOfferTabeDto>> GetPanelCutterOfferTableAsync(string panelCutterId)
        {
            var offers = (await Get()).Where(e => e.PanelCutterId == panelCutterId).ToList();

            var result = new List<PanelCutterOfferTabeDto>();
            foreach (var offer in offers)
            {
                result.Add(new PanelCutterOfferTabeDto()
                {
                    DesignerName = (await _designerService.FindByIdAsync(offer.DesginerId)).Name
                });
            }

            return result;
        }
    }
}
