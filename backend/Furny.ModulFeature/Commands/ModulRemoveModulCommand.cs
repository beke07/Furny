using Furny.Common.Commands;

namespace Furny.ModulFeature.Commands
{
    public class ModulRemoveModulCommand : IRemoveSingleElementCommandBase
    {
        public ModulRemoveModulCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static ModulRemoveModulCommand Create(string id, string elementId)
            => new ModulRemoveModulCommand(id, elementId);
    }
}
