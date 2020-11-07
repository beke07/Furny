using Furny.Common.Enums;
using System;
using System.Collections.Generic;

namespace Furny.Data
{
    public class OfferCommand
    {
        public string _id { get; set; }

        public IList<OfferComponentCommand> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State { get; set; }
    }
}
