using Furny.Common.Commands;
using Furny.Common.Enums;

namespace Furny.OfferFeature.ViewModels
{
    public class OfferFeatureDesignerOfferTableViewModel : TableBaseViewModel
    {
        public string FurnitureName { get; set; }

        public OfferState State { get; set; }
    }
}
