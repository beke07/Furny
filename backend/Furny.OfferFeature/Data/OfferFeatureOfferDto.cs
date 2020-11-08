using Furny.Common.Enums;
using System;
using System.Collections.Generic;

namespace Furny.OfferFeature.Data
{
    public class OfferFeatureOfferDto
    {
        public string _id { get; set; }

        public IList<OfferFeatureOfferComponentDto> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State { get; set; }
    }
}
