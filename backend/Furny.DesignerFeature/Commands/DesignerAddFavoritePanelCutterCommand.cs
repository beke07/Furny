using MediatR;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerAddFavoritePanelCutterCommand : IRequest
    {
        public DesignerAddFavoritePanelCutterCommand(string id, string pid)
        {
            Id = id;
            Pid = pid;
        }

        public string Id { get; set; }

        public string Pid { get; set; }

        public static DesignerAddFavoritePanelCutterCommand Create(string id, string pid)
            => new DesignerAddFavoritePanelCutterCommand(id, pid);
    }
}
