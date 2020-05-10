using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles
{
    public class DesignerMappingProfiles : Profile
    {
        public DesignerMappingProfiles()
        {
            CreateMap<DesignerProfileDto, Designer>().ReverseMap();
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<ComponentTableDto, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulDto, Modul>().ReverseMap();
            CreateMap<ModulTableDto, Modul>().ReverseMap();
            CreateMap<FurnitureDto, Furniture>()
                .ForMember(e => e.Moduls, opt => opt.MapFrom<ModulResolver>())
                .ReverseMap()
                .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));
        }

        public class ModulResolver : IValueResolver<FurnitureDto, Furniture, SingleElement<Modul>>
        {
            private readonly IDesignerService _designerService;

            public ModulResolver(IDesignerService designerService)
            {
                _designerService = designerService;
            }

            public SingleElement<Modul> Resolve(FurnitureDto source, Furniture destination, SingleElement<Modul> destMember, ResolutionContext context)
            {
                var result = new SingleElement<Modul>();

                if (string.IsNullOrEmpty(source.DesignerId))
                {
                    return result;
                }

                var designer = _designerService.FindByIdAsync(source.DesignerId).Result;

                source.Moduls.ToList().ForEach(mid =>
                {
                    result.Add(designer.Moduls.FirstOrDefault(e => e.Id == ObjectId.Parse(mid)));
                });

                return result;
            }
        }
    }
}
