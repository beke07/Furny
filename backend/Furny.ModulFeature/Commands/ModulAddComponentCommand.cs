using Furny.ModulFeature.Data;
using MediatR;

namespace Furny.ModulFeature.Commands
{
    public class ModulAddComponentCommand : IRequest
    {
        public ModulAddComponentCommand(ModulComponentDto component, string id, string mid)
        {
            Component = component;
            Id = id;
            Mid = mid;
        }

        public ModulComponentDto Component { get; set; }

        public string Id { get; set; }

        public string Mid { get; set; }

        public static ModulAddComponentCommand Create(ModulComponentDto component, string id, string mid)
            => new ModulAddComponentCommand(component, id, mid);
    }
}