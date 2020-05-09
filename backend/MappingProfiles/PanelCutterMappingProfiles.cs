using AutoMapper;
using Furny.Data;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class PanelCutterMappingProfiles : Profile
    {
        public PanelCutterMappingProfiles()
        {
            CreateMap<PanelCutterProfileDto, PanelCutter>().ReverseMap();
            CreateMap<MaterialDto, Material>().ReverseMap();
            CreateMap<MaterialTableDto, Material>().ReverseMap();
        }
    }
}
