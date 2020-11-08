using Furny.OfferFeature.Data;
using MediatR;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetPanelCutterOfferCommand : IRequest<OfferFeaturePanelCutterOfferDto>
    {
        public OfferFeatureGetPanelCutterOfferCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OfferFeatureGetPanelCutterOfferCommand Create(string id)
            => new OfferFeatureGetPanelCutterOfferCommand(id);
    }
}