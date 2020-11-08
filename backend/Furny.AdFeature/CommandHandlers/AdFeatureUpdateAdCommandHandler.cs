using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureUpdateAdCommandHandler : UpdateSingleElementCommandBaseHandler<AdFeatureUpdateAdCommand, AdFeatureAdDto, AdFeatureAdTableViewModel>
    {
        public AdFeatureUpdateAdCommandHandler(IAdService adService) : base(adService)
        { }
    }
}
