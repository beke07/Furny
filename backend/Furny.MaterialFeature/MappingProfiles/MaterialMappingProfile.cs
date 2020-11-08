using AutoMapper;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ViewModels;
using Furny.Model;

namespace Furny.MaterialFeature.MappingProfiles
{
    public class MaterialMappingProfile : Profile
    {
        public MaterialMappingProfile()
        {
            CreateMap<MaterialFeatureMaterialDto, Material>().ReverseMap();
            CreateMap<MaterialFeatureMaterialTableViewModel, Material>().ReverseMap();
        }
    }
}
