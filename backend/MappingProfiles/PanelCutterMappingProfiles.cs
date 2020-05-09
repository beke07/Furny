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
            CreateMap<AdDto, Ad>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ConstructUsing(e => new Ad())
                .ReverseMap();
        }
    }
}
