using MediatR;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureDeclineOrderCommand : IRequest
    {
        public OrderFeatureDeclineOrderCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OrderFeatureDeclineOrderCommand Create(string id)
            => new OrderFeatureDeclineOrderCommand(id);
    }
}
