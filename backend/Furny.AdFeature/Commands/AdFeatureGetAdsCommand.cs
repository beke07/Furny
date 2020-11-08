using Furny.AdFeature.ViewModels;
using Furny.Common.Commands;
using System.Collections.Generic;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureGetAdsCommand : GetCommand<IList<AdFeatureAdTableViewModel>>, IGetSingleElementCommandBase
    {
        public AdFeatureGetAdsCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static AdFeatureGetAdsCommand Create(string id)
            => new AdFeatureGetAdsCommand(id);
    }
}
