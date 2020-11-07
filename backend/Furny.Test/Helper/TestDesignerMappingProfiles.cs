using AutoMapper;
using Furny.Data;
using Furny.Models;

namespace Furny.Test.Helper
{
    public class TestDesignerMappingProfiles : Profile
    {
        public TestDesignerMappingProfiles()
        {
            CreateMap<ComponentCommand, Component>().ReverseMap();
            CreateMap<ComponentTableCommand, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulCommand, Modul>().ReverseMap();
            CreateMap<ModulTableCommand, Modul>().ReverseMap();
        }
    }
}
