using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class PanelCutterOfferDto
    {
        public OfferDto Offer { get; set; }

        public IDictionary<string, string> MaterialQuantity { get; set; } = new Dictionary<string, string>();

        public long CountedPrice { get; set; }
    }
}
