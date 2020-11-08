using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.CommandHandlers;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureGetClosingsCommandHandler : GetSingleElementsCommandBaseHandler<ClosingFeatureGetClosingsCommand, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    {
        public ClosingFeatureGetClosingsCommandHandler(IClosingService closingService) : base(closingService)
        { }
    }
}
