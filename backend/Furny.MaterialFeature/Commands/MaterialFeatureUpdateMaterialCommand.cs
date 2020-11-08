using Furny.Common.Commands;
using Furny.MaterialFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureUpdateMaterialCommand : UpdateCommand<MaterialFeatureMaterialDto>, IUpdateSingleElementCommandBase<MaterialFeatureMaterialDto>
    {
        public MaterialFeatureUpdateMaterialCommand(JsonPatchDocument<MaterialFeatureMaterialDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static MaterialFeatureUpdateMaterialCommand Create(JsonPatchDocument<MaterialFeatureMaterialDto> patch, string id, string fid)
            => new MaterialFeatureUpdateMaterialCommand(patch, id, fid);
    }
}
