using AutoMapper;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.OfferFeature.Data;
using MediatR;
using MongoDB.Bson;
using System.Linq;

namespace Furny.OfferFeature.MappingProfiles.Resolvers
{
    public class MaterialResolver : IValueResolver<OfferFeatureOfferComponentDto, OfferComponent, Material>
    {
        private readonly IMediator _mediator;

        public MaterialResolver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Material Resolve(OfferFeatureOfferComponentDto source, OfferComponent destination, Material destMember, ResolutionContext context)
        {
            var panelCutter = _mediator.Send(GetPanelCutterCommand.Create(source.PanelCutterId)).Result;

            return panelCutter.Materials.FirstOrDefault(e => e.Id == ObjectId.Parse(source.MaterialId));
        }
    }
}
