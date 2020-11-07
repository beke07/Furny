using Furny.Common.Enums;

namespace Furny.Data
{
    public class OrderCommand
    {
        public string _id { get; set; }

        public OfferCommand Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OrderState? State { get; set; }
    }
}
