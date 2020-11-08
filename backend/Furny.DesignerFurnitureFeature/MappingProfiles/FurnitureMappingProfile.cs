using AutoMapper;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.MappingProfiles.Resolvers;
using Furny.DesignerFurnitureFeature.ViewModels;
using Furny.Model;
using System.Linq;

namespace Furny.DesignerFurnitureFeature.MappingProfiles
{
    public class FurnitureMappingProfile : Profile
    {
        public FurnitureMappingProfile()
        {
            CreateMap<DesignerFurnitureFurnitureDto, Furniture>()
                .ForMember(e => e.Moduls, opt => opt.MapFrom<FurnitureModulResolver>())
                .ReverseMap()
                .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));

            CreateMap<Furniture, DesignerFurnitureFurnitureTableViewModel>();

            CreateMap<DesignerFurnitureComponentDto, Component>().ReverseMap();
            CreateMap<DesignerFurnitureClosingsDto, Closings>().ReverseMap();
            CreateMap<DesignerFurnitureComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<Component, DesignerFurnitureComponentTableViewModel>();
        }
    }
}
