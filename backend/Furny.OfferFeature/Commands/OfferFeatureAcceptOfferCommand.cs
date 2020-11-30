using Furny.OrderFeature.Data;
using MediatR;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureAcceptOfferCommand : IRequest
    {
        public OfferFeatureAcceptOfferCommand(string id, OrderFeatureOrderFillDto fill)
        {
            Id = id;
            Fill = fill;
        }

        public string Id { get; set; }

        public OrderFeatureOrderFillDto Fill { get; set; }

        public static OfferFeatureAcceptOfferCommand Create(string id, OrderFeatureOrderFillDto fill)
            => new OfferFeatureAcceptOfferCommand(id, fill);
    }
}
