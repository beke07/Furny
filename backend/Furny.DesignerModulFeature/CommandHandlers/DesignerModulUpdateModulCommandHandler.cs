using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulUpdateModulCommandHandler : UpdateSingleElementCommandBaseHandler<DesignerModulUpdateModulCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulUpdateModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
