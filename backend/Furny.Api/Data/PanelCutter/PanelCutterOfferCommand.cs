using System.Collections.Generic;

namespace Furny.Data
{
    public class PanelCutterOfferCommand
    {
        public OfferCommand Offer { get; set; }

        public IDictionary<string, string> MaterialQuantity { get; set; } = new Dictionary<string, string>();

        public long CountedPrice { get; set; }
    }
}
