using Furny.OfferFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetPanelCutterOfferTableCommand : IRequest<IList<OfferFeaturePanelCutterOfferTableViewModel>>
    {
        public OfferFeatureGetPanelCutterOfferTableCommand(string panelCutterId)
        {
            PanelCutterId = panelCutterId;
        }

        public string PanelCutterId { get; set; }

        public static OfferFeatureGetPanelCutterOfferTableCommand Create(string id)
            => new OfferFeatureGetPanelCutterOfferTableCommand(id);
    }
}