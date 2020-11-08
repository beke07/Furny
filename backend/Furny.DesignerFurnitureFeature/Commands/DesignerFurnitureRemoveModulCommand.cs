using MediatR;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureRemoveModulCommand : IRequest
    {
        public DesignerFurnitureRemoveModulCommand(string id, string fid, string mid)
        {
            Id = id;
            Fid = fid;
            Mid = mid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Mid { get; set; }

        public static DesignerFurnitureRemoveModulCommand Create(string id, string fid, string mid)
            => new DesignerFurnitureRemoveModulCommand(id, fid, mid);
    }
}
