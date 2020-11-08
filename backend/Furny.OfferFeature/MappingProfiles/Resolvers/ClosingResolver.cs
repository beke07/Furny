using AutoMapper;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.OfferFeature.Data;
using MediatR;
using MongoDB.Bson;
using System.Linq;

namespace Furny.OfferFeature.MappingProfiles.Resolvers
{
    public class ClosingResolver : IValueResolver<OfferFeatureOfferComponentDto, OfferComponent, Closing>
    {
        private readonly IMediator _mediator;

        public ClosingResolver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Closing Resolve(OfferFeatureOfferComponentDto source, OfferComponent destination, Closing destMember, ResolutionContext context)
        {
            var panelCutter = _mediator.Send(GetPanelCutterCommand.Create(source.PanelCutterId)).Result;

            return panelCutter.Closings.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ClosingId));
        }
    }
}
