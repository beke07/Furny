using Furny.Common.Commands;
using Furny.ModulFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.ModulFeature.Commands
{
    public class ModulUpdateModulCommand : UpdateCommand<ModulModulDto>, IUpdateSingleElementCommandBase<ModulModulDto>
    {
        public ModulUpdateModulCommand(JsonPatchDocument<ModulModulDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static ModulUpdateModulCommand Create(JsonPatchDocument<ModulModulDto> patch, string id, string fid)
            => new ModulUpdateModulCommand(patch, id, fid);
    }
}
