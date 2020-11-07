using MediatR;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerRemoveFavoritePanelCutterCommand : IRequest
    {
        public DesignerRemoveFavoritePanelCutterCommand(string id, string pid)
        {
            Id = id;
            Pid = pid;
        }

        public string Id { get; set; }

        public string Pid { get; set; }

        public static DesignerRemoveFavoritePanelCutterCommand Create(string id, string pid)
            => new DesignerRemoveFavoritePanelCutterCommand(id, pid);
    }
}
