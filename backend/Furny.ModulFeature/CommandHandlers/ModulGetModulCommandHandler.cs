using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulGetModulCommandHandler : GetSingleElementCommandBaseHandler<ModulGetModulCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulGetModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
