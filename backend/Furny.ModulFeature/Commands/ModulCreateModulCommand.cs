using Furny.Common.Commands;
using Furny.ModulFeature.Data;

namespace Furny.ModulFeature.Commands
{
    public class ModulCreateModulCommand : ICreateSingleElementCommandBase<ModulModulDto>
    {
        public ModulCreateModulCommand(string id, ModulModulDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public ModulModulDto Element { get; set; }

        public static ModulCreateModulCommand Create(string id, ModulModulDto element)
            => new ModulCreateModulCommand(id, element);
    }
}
