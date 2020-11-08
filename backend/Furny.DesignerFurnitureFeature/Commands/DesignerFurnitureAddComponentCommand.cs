using Furny.DesignerFurnitureFeature.Data;
using MediatR;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureAddComponentCommand : IRequest
    {
        public DesignerFurnitureAddComponentCommand(string id, string fid, DesignerFurnitureComponentDto component)
        {
            Id = id;
            Fid = fid;
            Component = component;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public DesignerFurnitureComponentDto Component { get; set; }

        public static DesignerFurnitureAddComponentCommand Create(string id, string fid, DesignerFurnitureComponentDto component)
            => new DesignerFurnitureAddComponentCommand(id, fid, component);
    }
}
