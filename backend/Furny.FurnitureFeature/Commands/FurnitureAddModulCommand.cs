using MediatR;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureAddModulCommand : IRequest
    {
        public FurnitureAddModulCommand(string id, string fid, string mid)
        {
            Id = id;
            Fid = fid;
            Mid = mid;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public string Mid { get; set; }

        public static FurnitureAddModulCommand Create(string id, string fid, string mid)
            => new FurnitureAddModulCommand(id, fid, mid);
    }
}
