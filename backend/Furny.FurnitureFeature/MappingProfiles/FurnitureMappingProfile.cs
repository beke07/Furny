using AutoMapper;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.MappingProfiles.Resolvers;
using Furny.FurnitureFeature.ViewModels;
using Furny.Model;
using System.Linq;

namespace Furny.FurnitureFeature.MappingProfiles
{
    public class FurnitureMappingProfile : Profile
    {
        public FurnitureMappingProfile()
        {
            CreateMap<FurnitureFurnitureDto, Furniture>()
                .ForMember(e => e.Moduls, opt => opt.MapFrom<FurnitureModulResolver>())
                .ReverseMap()
                .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));

            CreateMap<Furniture, FurnitureFurnitureTableViewModel>();

            CreateMap<FurnitureComponentDto, Component>().ReverseMap();
            CreateMap<FurnitureClosingsDto, Closings>().ReverseMap();
            CreateMap<Component, FurnitureComponentTableViewModel>();
        }
    }
}
