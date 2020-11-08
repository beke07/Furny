using Furny.Common.Commands;
using Furny.ModulFeature.Data;

namespace Furny.ModulFeature.Commands
{
    public class ModulGetModulCommand : GetCommand<ModulModulDto>, IGetSingleElementCommandBase
    {
        public ModulGetModulCommand(string id, string elementId) : base(id)
        {
            ElementId = elementId;
        }

        public string ElementId { get; set; }

        public static ModulGetModulCommand Create(string id, string elementId)
            => new ModulGetModulCommand(id, elementId);
    }
}
