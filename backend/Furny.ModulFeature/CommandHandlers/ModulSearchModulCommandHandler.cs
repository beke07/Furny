using Furny.Common.CommandHandlers;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;

namespace Furny.ModulFeature.Commands
{
    public class ModulSearchModulCommandHandler : SearchSingleElementCommandBaseHandler<ModulSearchModulCommand, ModulModulDto, ModulTableViewModel>
    {
        public ModulSearchModulCommandHandler(IModulService modulService) : base(modulService)
        { }
    }
}
