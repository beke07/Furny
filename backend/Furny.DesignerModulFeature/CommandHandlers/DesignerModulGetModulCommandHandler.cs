using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulGetModulCommandHandler : GetSingleElementCommandBaseHandler<DesignerModulGetModulCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulGetModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
