using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles.Resolvers
{
    public class ComponentResolver : IValueResolver<OfferComponentCommand, OfferComponent, Component>
    {
        private readonly IDesignerService _designerService;

        public ComponentResolver(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public Component Resolve(OfferComponentCommand source, OfferComponent destination, Component destMember, ResolutionContext context)
        {
            var desginer = _designerService.FindByIdAsync(source.DesignerId).Result;
            var furniture = desginer.Furnitures.FirstOrDefault(e => e.Id == ObjectId.Parse(source.FurnitureId));
            var component = furniture.Components.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));

            if (component == null)
            {
                component = furniture.Moduls.SelectMany(e => e.Components).FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));
            }

            return component;
        }
    }
}
