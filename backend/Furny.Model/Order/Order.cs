using Furny.Common.Enums;
using Furny.Common.Models;

namespace Furny.Model
{
    public class Order : MongoEntityBase
    {
        public Order() : base()
        { }

        public Order(string id) : base(id)
        { }

        public Offer Offer { get; set; }

        public bool Delivery { get; set; }

        public string Comment { get; set; }

        public OrderState? State { get; set; }
    }
}
