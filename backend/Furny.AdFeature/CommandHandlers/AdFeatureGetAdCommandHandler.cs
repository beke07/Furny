using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureGetAdCommandHandler : GetSingleElementCommandBaseHandler<AdFeatureGetAdCommand, AdFeatureAdDto, AdFeatureAdTableViewModel>
    {
        public AdFeatureGetAdCommandHandler(IAdService adService) : base(adService)
        { }
    }
}
