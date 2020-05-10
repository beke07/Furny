using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class OfferComponentDto
    {
        public string DesignerId { get; set; }

        public string FurnitureId { get; set; }

        public string ComponentId { get; set; }

        public string PanelCutterId { get; set; }

        public string MaterialId { get; set; }

        public string ClosingId { get; set; }
    }
}
