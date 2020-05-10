using System;
using System.Collections.Generic;
using static Furny.Common.Enums;

namespace Furny.Models
{
    public class Offer : MongoEntityBase
    {
        public Offer() : base()
        { }

        public Offer(string id) : base(id)
        { }

        public string PanelCutterId { get; set; }

        public string DesginerId { get; set; }

        public string FurnitureId { get; set; }

        public IList<OfferComponent> Components { get; set; }

        public long? Price { get; set; }

        public DateTime? Deadline { get; set; }

        public OfferState State
        {
            get
            {
                if(Price == null && Deadline == null)
                {
                    return OfferState.Created;
                }

                return OfferState.Done;
            }
        }
    }
}
