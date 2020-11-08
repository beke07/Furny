using Furny.Common.Enums;
using System;
using System.Collections.Generic;

namespace Furny.OrderFeature.ViewModels
{
    public class OrderFeatureOfferViewModel
    {
        public string _id { get; set; }

        public IList<OrderFeatureOfferComponentViewModel> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State { get; set; }
    }
}
