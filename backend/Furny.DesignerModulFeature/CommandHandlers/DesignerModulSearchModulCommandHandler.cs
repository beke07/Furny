using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulSearchModulCommandHandler : SearchSingleElementCommandBaseHandler<DesignerModulSearchModulCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulSearchModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
