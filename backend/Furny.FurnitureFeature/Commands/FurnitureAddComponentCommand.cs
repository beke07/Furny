using Furny.FurnitureFeature.Data;
using MediatR;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureAddComponentCommand : IRequest
    {
        public FurnitureAddComponentCommand(string id, string fid, FurnitureComponentDto component)
        {
            Id = id;
            Fid = fid;
            Component = component;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public FurnitureComponentDto Component { get; set; }

        public static FurnitureAddComponentCommand Create(string id, string fid, FurnitureComponentDto component)
            => new FurnitureAddComponentCommand(id, fid, component);
    }
}
