using MediatR;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulCopyComponentCommand : IRequest
    {
        public DesignerModulCopyComponentCommand(string id, string mid, string cid)
        {
            Id = id;
            Mid = mid;
            Cid = cid;
        }

        public string Id { get; set; }

        public string Mid { get; set; }

        public string Cid { get; set; }

        public static DesignerModulCopyComponentCommand Create(string id, string mid, string cid)
            => new DesignerModulCopyComponentCommand(id, mid, cid);
    }
}