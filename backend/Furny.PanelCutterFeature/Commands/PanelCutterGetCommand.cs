using Furny.Common.Commands;
using Furny.PanelCutterFeature.ViewModels;

namespace Furny.PanelCutterFeature.Commands
{
    public class PanelCutterGetCommand : GetCommand<PanelCutterHomeViewModel>
    {
        public PanelCutterGetCommand(string id) : base(id)
        { }

        public static PanelCutterGetCommand Create(string id)
            => new PanelCutterGetCommand(id);
    }
}
