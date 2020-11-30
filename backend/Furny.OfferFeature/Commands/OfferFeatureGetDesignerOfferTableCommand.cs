using Furny.OfferFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetDesignerOfferTableCommand : IRequest<IList<OfferFeatureDesignerOfferTableViewModel>>
    {
        public OfferFeatureGetDesignerOfferTableCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OfferFeatureGetDesignerOfferTableCommand Create(string id)
            => new OfferFeatureGetDesignerOfferTableCommand(id);
    }
}