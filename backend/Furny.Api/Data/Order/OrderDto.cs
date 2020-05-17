using static Furny.Common.Enums;

namespace Furny.Data
{
    public class OrderDto
    {
        public string _id { get; set; }

        public OfferDto Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OrderState? State { get; set; }
    }
}
