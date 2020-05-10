using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Models
{
    public class OfferComponent
    {
        public Component Component { get; set; }

        public Material Material { get; set; }

        public Closing Closing { get; set; }
    }
}
