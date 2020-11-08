using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulRemoveModulCommandHandler : RemoveSingleElementCommandBaseHandler<ModulRemoveModulCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulRemoveModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
