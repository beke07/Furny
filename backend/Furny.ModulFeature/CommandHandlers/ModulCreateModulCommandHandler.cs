using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulCreateModulCommandHandler : CreateSingleElementCommandBaseHandler<ModulCreateModulCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulCreateModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
