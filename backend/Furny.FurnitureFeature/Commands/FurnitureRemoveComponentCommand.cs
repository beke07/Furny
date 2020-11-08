using MediatR;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureRemoveComponentCommand : IRequest
    {
        public FurnitureRemoveComponentCommand(string id, string fid, string cid)
        {
            Id = id;
            Fid = fid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Cid { get; set; }

        public static FurnitureRemoveComponentCommand Create(string id, string fid, string cid)
            => new FurnitureRemoveComponentCommand(id, fid, cid);
    }
}
