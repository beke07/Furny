using Furny.AdFeature.Commands;
using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureGetAdsCommandHandler : GetSingleElementsCommandBaseHandler<AdFeatureGetAdsCommand, AdFeatureAdDto, AdFeatureAdTableViewModel>
    {
        public AdFeatureGetAdsCommandHandler(IAdService adService) : base(adService)
        { }
    }
}
