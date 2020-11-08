using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureCreateClosingCommandHandler : CreateSingleElementCommandBaseHandler<ClosingFeatureCreateClosingCommand, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    {
        public ClosingFeatureCreateClosingCommandHandler(IClosingService closingService) : base(closingService)
        { }
    }
}
