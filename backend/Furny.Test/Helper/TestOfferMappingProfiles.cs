using AutoMapper;
using Furny.Data;
using Furny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furny.Test.Helper
{
    public class TestOfferMappingProfiles : Profile
    {
        public TestOfferMappingProfiles()
        {
            CreateMap<Offer, OfferDto>();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
