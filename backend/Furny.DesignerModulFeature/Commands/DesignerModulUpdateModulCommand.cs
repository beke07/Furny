using Furny.Common.Commands;
using Furny.DesignerModulFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulUpdateModulCommand : UpdateCommand<DesignerModulModulDto>, IUpdateSingleElementCommandBase<DesignerModulModulDto>
    {
        public DesignerModulUpdateModulCommand(JsonPatchDocument<DesignerModulModulDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static DesignerModulUpdateModulCommand Create(JsonPatchDocument<DesignerModulModulDto> patch, string id, string fid)
            => new DesignerModulUpdateModulCommand(patch, id, fid);
    }
}
