using static Furny.Common.Enums;

namespace Furny.Data
{
    public class OrderDto
    {
        public OfferDto Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OfferState State { get; set; }
    }
}
