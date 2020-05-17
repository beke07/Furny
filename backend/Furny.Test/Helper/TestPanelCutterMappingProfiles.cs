using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furny.Test.Helper
{
    public class TestPanelCutterMappingProfiles : Profile
    {
        public TestPanelCutterMappingProfiles()
        {
            CreateMap<Ad, DesignerAdDto>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<DesignerAdResolver>());

            CreateMap<MaterialDto, Material>().ReverseMap();
            CreateMap<MaterialTableDto, Material>().ReverseMap();
            CreateMap<ClosingTableDto, Closing>().ReverseMap();
            CreateMap<ClosingDto, Closing>().ReverseMap();
            CreateMap<AdDto, Ad>().ReverseMap();
            CreateMap<AdTableDto, Ad>().ReverseMap();
        }
    }
}
