using AutoMapper;
using Furny.Data;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class OfferMappingProfiles : Profile
    {
        public OfferMappingProfiles()
        {
            CreateMap<OfferComponentCommand, OfferComponent>()
                .ForMember(e => e.Component, opt => opt.MapFrom<ComponentResolver>())
                .ForMember(e => e.Closing, opt => opt.MapFrom<ClosingResolver>())
                .ForMember(e => e.Material, opt => opt.MapFrom<MaterialResolver>())
                .ReverseMap();

            CreateMap<Offer, OfferCommand>();
            CreateMap<Order, OrderCommand>().ReverseMap();
        }
    }
}
