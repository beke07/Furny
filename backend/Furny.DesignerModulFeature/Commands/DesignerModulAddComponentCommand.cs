using Furny.DesignerModulFeature.Data;
using MediatR;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulAddComponentCommand : IRequest
    {
        public DesignerModulAddComponentCommand(DesignerModulComponentDto component, string id, string mid)
        {
            Component = component;
            Id = id;
            Mid = mid;
        }

        public DesignerModulComponentDto Component { get; set; }

        public string Id { get; set; }

        public string Mid { get; set; }

        public static DesignerModulAddComponentCommand Create(DesignerModulComponentDto component, string id, string mid)
            => new DesignerModulAddComponentCommand(component, id, mid);
    }
}