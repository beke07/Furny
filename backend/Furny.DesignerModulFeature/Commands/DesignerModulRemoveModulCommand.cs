using Furny.Common.Commands;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulRemoveModulCommand : IRemoveSingleElementCommandBase
    {
        public DesignerModulRemoveModulCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static DesignerModulRemoveModulCommand Create(string id, string elementId)
            => new DesignerModulRemoveModulCommand(id, elementId);
    }
}
