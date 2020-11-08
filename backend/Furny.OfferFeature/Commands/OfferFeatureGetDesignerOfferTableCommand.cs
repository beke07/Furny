using Furny.OfferFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.OfferFeature.Commands
{
    public class OfferFeatureGetDesignerOfferTableCommand : IRequest<IList<OfferFeatureDesignerOfferTableViewModel>>
    {
        public OfferFeatureGetDesignerOfferTableCommand(string id, string fid)
        {
            Id = id;
            Fid = fid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public static OfferFeatureGetDesignerOfferTableCommand Create(string id, string fid)
            => new OfferFeatureGetDesignerOfferTableCommand(id, fid);
    }
}