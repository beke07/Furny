using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureRemoveAdCommandHandler : RemoveSingleElementCommandBaseHandler<AdFeatureRemoveAdCommand, AdFeatureAdDto, AdFeatureAdTableViewModel>
    {
        public AdFeatureRemoveAdCommandHandler(IAdService adService) : base(adService)
        { }
    }
}
