using System.Collections.Generic;

namespace Furny.OfferFeature.Data
{
    public class OfferFeaturePanelCutterOfferDto
    {
        public OfferFeatureOfferDto Offer { get; set; }

        public IDictionary<string, string> MaterialQuantity { get; set; } = new Dictionary<string, string>();

        public IDictionary<string, string> ClosingQuantity { get; set; } = new Dictionary<string, string>();

        public long CountedPrice { get; set; }
    }
}
