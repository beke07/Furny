using Furny.Common.Commands;

namespace Furny.Model.Common.Commands
{
    public class GetPanelCutterCommand : GetCommand<PanelCutter>
    {
        public GetPanelCutterCommand(string id) : base(id)
        { }

        public static GetPanelCutterCommand Create(string id)
            => new GetPanelCutterCommand(id);
    }
}
