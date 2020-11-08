using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulRemoveModulCommandHandler : RemoveSingleElementCommandBaseHandler<DesignerModulRemoveModulCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulRemoveModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
