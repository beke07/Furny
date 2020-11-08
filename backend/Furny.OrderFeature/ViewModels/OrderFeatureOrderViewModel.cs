using Furny.Common.Enums;

namespace Furny.OrderFeature.ViewModels
{
    public class OrderFeatureOrderViewModel
    {
        public string _id { get; set; }

        public OrderFeatureOfferViewModel Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OrderState? State { get; set; }
    }
}
