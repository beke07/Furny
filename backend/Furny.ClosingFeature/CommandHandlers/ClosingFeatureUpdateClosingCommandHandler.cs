using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureUpdateClosingCommandHandler : UpdateSingleElementCommandBaseHandler<ClosingFeatureUpdateClosingCommand, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    {
        public ClosingFeatureUpdateClosingCommandHandler(IClosingService closingService) : base(closingService)
        { }
    }
}
