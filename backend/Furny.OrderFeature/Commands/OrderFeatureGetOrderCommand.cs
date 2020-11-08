using Furny.OrderFeature.ViewModels;
using MediatR;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureGetOrderCommand : IRequest<OrderFeatureOrderViewModel>
    {
        public OrderFeatureGetOrderCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OrderFeatureGetOrderCommand Create(string id)
            => new OrderFeatureGetOrderCommand(id);
    }
}
