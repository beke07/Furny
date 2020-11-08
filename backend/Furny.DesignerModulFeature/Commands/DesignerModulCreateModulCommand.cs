using Furny.Common.Commands;
using Furny.DesignerModulFeature.Data;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulCreateModulCommand : ICreateSingleElementCommandBase<DesignerModulModulDto>
    {
        public DesignerModulCreateModulCommand(string id, DesignerModulModulDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public DesignerModulModulDto Element { get; set; }

        public static DesignerModulCreateModulCommand Create(string id, DesignerModulModulDto element)
            => new DesignerModulCreateModulCommand(id, element);
    }
}
