using Furny.Model;
using MediatR;

namespace Furny.OrderFeature.Commands
{
    public class OrderFeatureCreateOrderCommand : IRequest
    {
        public OrderFeatureCreateOrderCommand(Offer offer)
        {
            Offer = offer;
        }

        public Offer Offer { get; set; }

        public static OrderFeatureCreateOrderCommand Create(Offer offer)
            => new OrderFeatureCreateOrderCommand(offer);
    }
}
