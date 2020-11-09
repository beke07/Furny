using AutoMapper;
using Furny.Model;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.MappingProfiles.Resolvers;

namespace Furny.OfferFeature.MappingProfiles
{
    public class OfferMappingProfile : Profile
    {
        public OfferMappingProfile()
        {
            CreateMap<OfferFeatureOfferComponentDto, OfferComponent>()
                .ForMember(e => e.Component, opt => opt.MapFrom<ComponentResolver>())
                .ForMember(e => e.Closing, opt => opt.MapFrom<ClosingResolver>())
                .ForMember(e => e.Material, opt => opt.MapFrom<MaterialResolver>())
                .ReverseMap();

            CreateMap<Offer, OfferFeatureOfferDto>();
            CreateMap<Order, OfferFeatureOfferDto>().ReverseMap();
        }
    }
}
