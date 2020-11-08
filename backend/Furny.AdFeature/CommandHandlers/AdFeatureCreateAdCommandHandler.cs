using Furny.AdFeature.Commands;
using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureCreateAdCommandHandler : CreateSingleElementCommandBaseHandler<AdFeatureCreateAdCommand, AdFeatureAdDto, AdFeatureAdTableViewModel>
    {
        public AdFeatureCreateAdCommandHandler(IAdService adService) : base(adService)
        { }
    }
}
