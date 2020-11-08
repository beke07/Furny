using AutoMapper;
using Furny.Model;
using Furny.OrderFeature.ViewModels;

namespace Furny.OrderFeature.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderFeatureOrderViewModel>();
            CreateMap<Offer, OrderFeatureOfferViewModel>();
            CreateMap<OfferComponent, OrderFeatureOfferComponentViewModel>();
        }
    }
}
