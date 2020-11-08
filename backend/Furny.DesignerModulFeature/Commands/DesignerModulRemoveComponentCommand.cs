using MediatR;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulRemoveComponentCommand : IRequest
    {
        public DesignerModulRemoveComponentCommand(string id, string mid, string cid)
        {
            Id = id;
            Mid = mid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Mid { get; set; }

        public string Cid { get; set; }

        public static DesignerModulRemoveComponentCommand Create(string id, string mid, string cid)
            => new DesignerModulRemoveComponentCommand(id, mid, cid);
    }
}