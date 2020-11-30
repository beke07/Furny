using MediatR;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureDeclineOfferCommand : IRequest
    {
        public OfferFeatureDeclineOfferCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static OfferFeatureDeclineOfferCommand Create(string id)
            => new OfferFeatureDeclineOfferCommand(id);
    }
}
