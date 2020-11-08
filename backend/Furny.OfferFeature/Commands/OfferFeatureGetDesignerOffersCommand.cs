using Furny.OfferFeature.Data;
using MediatR;
using System.Collections.Generic;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetDesignerOffersCommand : IRequest<IList<OfferFeatureOfferDto>>
    {
        public OfferFeatureGetDesignerOffersCommand(string id, string fid)
        {
            Id = id;
            Fid = fid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public static OfferFeatureGetDesignerOffersCommand Create(string id, string fid)
            => new OfferFeatureGetDesignerOffersCommand(id, fid);
    }
}