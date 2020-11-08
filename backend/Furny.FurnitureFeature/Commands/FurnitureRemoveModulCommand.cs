using MediatR;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureRemoveModulCommand : IRequest
    {
        public FurnitureRemoveModulCommand(string id, string fid, string mid)
        {
            Id = id;
            Fid = fid;
            Mid = mid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Mid { get; set; }

        public static FurnitureRemoveModulCommand Create(string id, string fid, string mid)
            => new FurnitureRemoveModulCommand(id, fid, mid);
    }
}
