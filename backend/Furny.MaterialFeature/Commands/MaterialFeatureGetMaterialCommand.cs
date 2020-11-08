using Furny.Common.Commands;
using Furny.MaterialFeature.Data;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureGetMaterialCommand : GetCommand<MaterialFeatureMaterialDto>, IGetSingleElementCommandBase
    {
        public MaterialFeatureGetMaterialCommand(string id, string fid) : base(id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static MaterialFeatureGetMaterialCommand Create(string id, string fid)
            => new MaterialFeatureGetMaterialCommand(id, fid);
    }
}
