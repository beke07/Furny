using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles.Resolvers
{
    public class MaterialResolver : IValueResolver<OfferComponentCommand, OfferComponent, Material>
    {
        private readonly IPanelCutterService _panelCutterService;

        public MaterialResolver(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public Material Resolve(OfferComponentCommand source, OfferComponent destination, Material destMember, ResolutionContext context)
        {
            var panelCutter = _panelCutterService.FindByIdAsync(source.PanelCutterId).Result;
            return panelCutter.Materials.FirstOrDefault(e => e.Id == ObjectId.Parse(source.MaterialId));
        }
    }
}
