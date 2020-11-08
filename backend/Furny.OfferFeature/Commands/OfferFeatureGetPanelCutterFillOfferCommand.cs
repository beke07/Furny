using Furny.OfferFeature.Data;
using MediatR;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetPanelCutterFillOfferCommand : IRequest
    {
        public OfferFeatureGetPanelCutterFillOfferCommand(string id, OfferFeaturePanelCutterFillOfferDto fill)
        {
            Id = id;
            Fill = fill;
        }

        public string Id { get; set; }

        public OfferFeaturePanelCutterFillOfferDto Fill { get; set; }

        public static OfferFeatureGetPanelCutterFillOfferCommand Create(string id, OfferFeaturePanelCutterFillOfferDto fill)
            => new OfferFeatureGetPanelCutterFillOfferCommand(id, fill);
    }
}