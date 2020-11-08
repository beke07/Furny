using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulCreateModulCommandHandler : CreateSingleElementCommandBaseHandler<DesignerModulCreateModulCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulCreateModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
