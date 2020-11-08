using AutoMapper;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ViewModels;
using Furny.Model;

namespace Furny.DesignerModulFeature.MappingProfiles
{
    public class ModulMappingProfile : Profile
    {
        public ModulMappingProfile()
        {
            CreateMap<DesignerModulModulDto, Modul>().ReverseMap();
            CreateMap<DesignerModulModulTableViewModel, Modul>().ReverseMap();
            CreateMap<DesignerModulComponentDto, Component>().ReverseMap();
            CreateMap<DesignerModulComponentClosingDto, Closings>().ReverseMap();
            CreateMap<DesignerModulClosingsDto, ComponentClosing>().ReverseMap();
        }
    }
}
