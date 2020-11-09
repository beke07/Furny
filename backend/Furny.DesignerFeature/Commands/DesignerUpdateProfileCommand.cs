using Furny.Common.Commands;
using Furny.DesignerFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerUpdateProfileCommand : UpdateCommand<DesignerProfileDto>
    {
        public DesignerUpdateProfileCommand(JsonPatchDocument<DesignerProfileDto> patch, string id) : base(patch, id)
        { }

        public static DesignerUpdateProfileCommand Create(JsonPatchDocument<DesignerProfileDto> patch, string id)
            => new DesignerUpdateProfileCommand(patch, id);
    }
}
