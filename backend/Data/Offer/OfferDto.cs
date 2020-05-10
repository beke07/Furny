using System;
using System.Collections.Generic;
using static Furny.Common.Enums;

namespace Furny.Data
{
    public class OfferDto
    {
        public string _id { get; set; }

        public IList<OfferComponentDto> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State { get; set; }
    }
}
