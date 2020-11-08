using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulGetModulsCommandHandler : GetSingleElementsCommandBaseHandler<ModulGetModulsCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulGetModulsCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
