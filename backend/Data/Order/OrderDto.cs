using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Furny.Common.Enums;

namespace Furny.Data.Order
{
    public class OrderDto
    {
        public OfferDto Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OfferState State { get; set; }
    }
}
