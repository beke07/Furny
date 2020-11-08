using AutoMapper;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.OfferFeature.Data;
using MediatR;
using MongoDB.Bson;
using System.Linq;

namespace Furny.OfferFeature.MappingProfiles.Resolvers
{
    public class ComponentResolver : IValueResolver<OfferFeatureOfferComponentDto, OfferComponent, Component>
    {
        private readonly IMediator _mediator;

        public ComponentResolver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Component Resolve(OfferFeatureOfferComponentDto source, OfferComponent destination, Component destMember, ResolutionContext context)
        {
            var designer = _mediator.Send(GetDesignerCommand.Create(source.DesignerId)).Result;
            var furniture = designer.Furnitures.FirstOrDefault(e => e.Id == ObjectId.Parse(source.FurnitureId));
            var component = furniture.Components.FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));

            if (component == null)
            {
                component = furniture.Moduls.SelectMany(e => e.Components).FirstOrDefault(e => e.Id == ObjectId.Parse(source.ComponentId));
            }

            return component;
        }
    }
}
