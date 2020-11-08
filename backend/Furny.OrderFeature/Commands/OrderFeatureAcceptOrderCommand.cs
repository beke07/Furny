using Furny.OrderFeature.Data;
using MediatR;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureAcceptOrderCommand : IRequest
    {
        public OrderFeatureAcceptOrderCommand(string id, OrderFeatureOrderFillDto fill)
        {
            Id = id;
            Fill = fill;
        }

        public string Id { get; set; }

        public OrderFeatureOrderFillDto Fill { get; set; }

        public static OrderFeatureAcceptOrderCommand Create(string id, OrderFeatureOrderFillDto fill)
            => new OrderFeatureAcceptOrderCommand(id, fill);
    }
}
