using AutoMapper;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ViewModels;
using Furny.Model;

namespace Furny.ModulFeature.MappingProfiles
{
    public class ModulMappingProfile : Profile
    {
        public ModulMappingProfile()
        {
            CreateMap<ModulModulDto, Modul>().ReverseMap();
            CreateMap<ModulTableViewModel, Modul>().ReverseMap();
            CreateMap<ModulComponentDto, Component>().ReverseMap();
            CreateMap<ModulClosingsDto, Closings>().ReverseMap();
        }
    }
}
