using MediatR;

namespace Furny.ModulFeature.Commands
{
    public class ModulCopyComponentCommand : IRequest
    {
        public ModulCopyComponentCommand(string id, string mid, string cid)
        {
            Id = id;
            Mid = mid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Mid { get; set; }

        public string Cid { get; set; }

        public static ModulCopyComponentCommand Create(string id, string mid, string cid)
            => new ModulCopyComponentCommand(id, mid, cid);
    }
}