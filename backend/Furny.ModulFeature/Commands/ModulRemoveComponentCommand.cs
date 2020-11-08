using MediatR;

namespace Furny.ModulFeature.Commands
{
    public class ModulRemoveComponentCommand : IRequest
    {
        public ModulRemoveComponentCommand(string id, string mid, string cid)
        {
            Id = id;
            Mid = mid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Mid { get; set; }

        public string Cid { get; set; }

        public static ModulRemoveComponentCommand Create(string id, string mid, string cid)
            => new ModulRemoveComponentCommand(id, mid, cid);
    }
}