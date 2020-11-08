using Furny.Common.CommandHandlers;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulGetModulsCommandHandler : GetSingleElementsCommandBaseHandler<DesignerModulGetModulsCommand, DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        public DesignerModulGetModulsCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
