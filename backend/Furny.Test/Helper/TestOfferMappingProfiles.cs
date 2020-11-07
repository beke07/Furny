using AutoMapper;
using Furny.Data;
using Furny.Models;

namespace Furny.Test.Helper
{
    public class TestOfferMappingProfiles : Profile
    {
        public TestOfferMappingProfiles()
        {
            CreateMap<Offer, OfferCommand>();
            CreateMap<Order, OrderCommand>().ReverseMap();
        }
    }
}
