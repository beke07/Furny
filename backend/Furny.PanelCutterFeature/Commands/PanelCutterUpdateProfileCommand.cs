using Furny.Common.Commands;
using Furny.PanelCutterFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.PanelCutterFeature.Commands
{
    public class PanelCutterUpdateProfileCommand : UpdateCommand<PanelCutterProfileDto>
    {
        public PanelCutterUpdateProfileCommand(JsonPatchDocument<PanelCutterProfileDto> patch, string id) : base(patch, id)
        { }

        public static PanelCutterUpdateProfileCommand Create(JsonPatchDocument<PanelCutterProfileDto> patch, string id)
            => new PanelCutterUpdateProfileCommand(patch, id);
    }
}
