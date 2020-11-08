using MediatR;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureRemoveComponentCommand : IRequest
    {
        public DesignerFurnitureRemoveComponentCommand(string id, string fid, string cid)
        {
            Id = id;
            Fid = fid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Cid { get; set; }

        public static DesignerFurnitureRemoveComponentCommand Create(string id, string fid, string cid)
            => new DesignerFurnitureRemoveComponentCommand(id, fid, cid);
    }
}
