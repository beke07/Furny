using Furny.Common.Commands;
using Furny.Common.Enums;

namespace Furny.OfferFeature.ViewModels
{
    public class OfferFeaturePanelCutterOfferTableViewModel : TableBaseViewModel
    {
        public string DesignerName { get; set; }

        public OfferState? State { get; set; }
    }
}
