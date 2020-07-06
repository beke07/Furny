using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles.Resolvers
{
    public class ClosingResolver : IValueResolver<OfferComponentDto, OfferComponent, Closing>
    {
        private readonly IPanelCutterService _panelCutterService;

        public ClosingResolver(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public Closing Resolve(OfferComponentDto source, OfferComponent destination, Closing destMember, ResolutionContext context)
        {
            var panelCutter = _panelCutterService.FindByIdAsync(source.PanelCutterId).Result;
            return panelCutter.Closings.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ClosingId));
        }
    }
}
