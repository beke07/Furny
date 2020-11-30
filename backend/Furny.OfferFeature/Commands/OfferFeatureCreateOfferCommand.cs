
using Furny.OfferFeature.Data;
using MediatR;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureCreateOfferCommand : IRequest
    {
        public OfferFeatureCreateOfferCommand(OfferFeatureOfferDto offer, string id, string fid)
        {
            Offer = offer;
            Id = id;
            Fid = fid;
        }

        public OfferFeatureOfferDto Offer { get; set; }

        public string Id { get; set; }

        public string Fid { get; set; }

        public static OfferFeatureCreateOfferCommand Create(OfferFeatureOfferDto offer, string id, string fid)
            => new OfferFeatureCreateOfferCommand(offer, id, fid);
    }
}
