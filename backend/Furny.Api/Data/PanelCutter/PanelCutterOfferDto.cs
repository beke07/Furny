using System.Collections.Generic;

namespace Furny.Data
{
    public class PanelCutterOfferDto
    {
        public OfferDto Offer { get; set; }

        public IDictionary<string, string> MaterialQuantity { get; set; } = new Dictionary<string, string>();

        public long CountedPrice { get; set; }
    }
}
