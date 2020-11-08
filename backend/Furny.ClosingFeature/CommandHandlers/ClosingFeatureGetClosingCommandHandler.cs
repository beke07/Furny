using Furny.ClosingFeature.Commands;
using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureGetClosingCommandHandler : GetSingleElementCommandBaseHandler<ClosingFeatureGetClosingCommand, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    {
        public ClosingFeatureGetClosingCommandHandler(IClosingService closingService) : base(closingService)
        { }
    }
}
