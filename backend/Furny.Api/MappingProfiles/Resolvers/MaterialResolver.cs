using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.MappingProfiles.Resolvers
{
    public class MaterialResolver : IValueResolver<OfferComponentDto, OfferComponent, Material>
    {
        private readonly IPanelCutterService _panelCutterService;

        public MaterialResolver(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public Material Resolve(OfferComponentDto source, OfferComponent destination, Material destMember, ResolutionContext context)
        {
            var panelCutter = _panelCutterService.FindByIdAsync(source.PanelCutterId).Result;
            return panelCutter.Materials.FirstOrDefault(e => e.Id == ObjectId.Parse(source.MaterialId));
        }
    }
}
