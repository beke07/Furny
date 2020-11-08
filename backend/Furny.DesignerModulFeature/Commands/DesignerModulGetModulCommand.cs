using Furny.Common.Commands;
using Furny.DesignerModulFeature.Data;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulGetModulCommand : GetCommand<DesignerModulModulDto>, IGetSingleElementCommandBase
    {
        public DesignerModulGetModulCommand(string id, string elementId) : base(id)
        {
            ElementId = elementId;
        }

        public string ElementId { get; set; }

        public static DesignerModulGetModulCommand Create(string id, string elementId)
            => new DesignerModulGetModulCommand(id, elementId);
    }
}
