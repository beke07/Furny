using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;

namespace Furny.Test.Helper
{
    public class TestPanelCutterMappingProfiles : Profile
    {
        public TestPanelCutterMappingProfiles()
        {
            CreateMap<Ad, DesignerAdCommand>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<DesignerAdResolver>());

            CreateMap<MaterialCommand, Material>().ReverseMap();
            CreateMap<MaterialTableCommand, Material>().ReverseMap();
            CreateMap<ClosingTableCommand, Closing>().ReverseMap();
            CreateMap<ClosingCommand, Closing>().ReverseMap();
            CreateMap<AdCommand, Ad>().ReverseMap();
            CreateMap<AdTableCommand, Ad>().ReverseMap();
        }
    }
}
