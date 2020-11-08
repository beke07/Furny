using MediatR;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureDoneOrderCommand : IRequest
    {
        public OrderFeatureDoneOrderCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OrderFeatureDoneOrderCommand Create(string id)
            => new OrderFeatureDoneOrderCommand(id);
    }
}
