using Furny.Common.Commands;
using Furny.MaterialFeature.Data;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureCreateMaterialCommand : ICreateSingleElementCommandBase<MaterialFeatureMaterialDto>
    {
        public MaterialFeatureCreateMaterialCommand(string id, MaterialFeatureMaterialDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public MaterialFeatureMaterialDto Element { get; set; }

        public static MaterialFeatureCreateMaterialCommand Create(string id, MaterialFeatureMaterialDto element)
            => new MaterialFeatureCreateMaterialCommand(id, element);
    }
}
