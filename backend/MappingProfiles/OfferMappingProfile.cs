using AutoMapper;
using Furny.Data;
using Furny.Data.Order;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles
{
    public class OfferMappingProfile : Profile
    {
        public OfferMappingProfile()
        {
            CreateMap<OfferComponentDto, OfferComponent>()
                .ForMember(e => e.Component, opt => opt.MapFrom<ComponentResolver>())
                .ForMember(e => e.Closing, opt => opt.MapFrom<ClosingResolver>())
                .ForMember(e => e.Material, opt => opt.MapFrom<MaterialResolver>())
                .ReverseMap();

            CreateMap<Offer, OfferDto>();

            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }

    public class ClosingResolver : IValueResolver<OfferComponentDto, OfferComponent, Closing>
    {
        private readonly IPanelCutterService _panelCutterService;

        public ClosingResolver(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public Closing Resolve(OfferComponentDto source, OfferComponent destination, Closing destMember, ResolutionContext context)
        {
            var panelCutter = _panelCutterService.FindByIdAsync(source.PanelCutterId).Result;
            return panelCutter.Closings.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ClosingId));
        }
    }

    public class MaterialResolver : IValueResolver<OfferComponentDto, OfferComponent, Material>
    {
        private readonly IPanelCutterService _panelCutterService;

        public MaterialResolver(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public Material Resolve(OfferComponentDto source, OfferComponent destination, Material destMember, ResolutionContext context)
        {
            var panelCutter = _panelCutterService.FindByIdAsync(source.PanelCutterId).Result;
            return panelCutter.Materials.FirstOrDefault(e => e.Id == ObjectId.Parse(source.MaterialId));
        }
    }

    public class ComponentResolver : IValueResolver<OfferComponentDto, OfferComponent, Component>
    {
        private readonly IDesignerService _designerService;

        public ComponentResolver(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public Component Resolve(OfferComponentDto source, OfferComponent destination, Component destMember, ResolutionContext context)
        {
            var desginer = _designerService.FindByIdAsync(source.DesignerId).Result;
            var furniture = desginer.Furnitures.FirstOrDefault(e => e.Id == ObjectId.Parse(source.FurnitureId));
            var component = furniture.Components.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));

            if(component == null)
            {
                component = furniture.Moduls.SelectMany(e => e.Components).FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));
            }

            return component;
        }
    }
}
