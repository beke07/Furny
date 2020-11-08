using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulUpdateModulCommandHandler : UpdateSingleElementCommandBaseHandler<ModulUpdateModulCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulUpdateModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
