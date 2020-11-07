using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles.Resolvers
{
    public class ModulResolver : IValueResolver<FurnitureCommand, Furniture, SingleElement<Modul>>
    {
        private readonly IDesignerService _designerService;

        public ModulResolver(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public SingleElement<Modul> Resolve(FurnitureCommand source, Furniture destination, SingleElement<Modul> destMember, ResolutionContext context)
        {
            var result = new SingleElement<Modul>();

            if (string.IsNullOrEmpty(source.DesignerId))
            {
                return result;
            }

            var designer = _designerService.FindByIdAsync(source.DesignerId).Result;

            if (source.Moduls != null && source.Moduls.Count > 0)
            {
                source.Moduls.ToList().ForEach(mid =>
                {
                    result.Add(designer.Moduls.FirstOrDefault(e => e.Id == ObjectId.Parse(mid)));
                });
            }

            return result;
        }
    }
}
