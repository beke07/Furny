using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureRemoveClosingCommandHandler : RemoveSingleElementCommandBaseHandler<ClosingFeatureRemoveClosingCommand, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    {
        public ClosingFeatureRemoveClosingCommandHandler(IClosingService closingService) : base(closingService)
        { }
    }
}
