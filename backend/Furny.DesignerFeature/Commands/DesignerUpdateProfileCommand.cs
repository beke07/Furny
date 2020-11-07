using Furny.Common.Commands;
using Furny.DesignerFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerUpdateProfileCommand : UpdateCommand<DesignerUpdateProfileDto>
    {
        public DesignerUpdateProfileCommand(JsonPatchDocument<DesignerUpdateProfileDto> patch, string id) : base(patch, id)
        { }

        public static DesignerUpdateProfileCommand Create(JsonPatchDocument<DesignerUpdateProfileDto> patch, string id)
            => new DesignerUpdateProfileCommand(patch, id);
    }
}
