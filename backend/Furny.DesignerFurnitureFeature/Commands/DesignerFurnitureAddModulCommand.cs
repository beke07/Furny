using MediatR;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureAddModulCommand : IRequest
    {
        public DesignerFurnitureAddModulCommand(string id, string fid, string mid)
        {
            Id = id;
            Fid = fid;
            Mid = mid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Mid { get; set; }

        public static DesignerFurnitureAddModulCommand Create(string id, string fid, string mid)
            => new DesignerFurnitureAddModulCommand(id, fid, mid);
    }
}
