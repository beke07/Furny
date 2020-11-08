using Furny.Common.CommandHandlers;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureGetMaterialCommandHandler : GetSingleElementCommandBaseHandler<MaterialFeatureGetMaterialCommand, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    {
        public MaterialFeatureGetMaterialCommandHandler(IMaterialService materialService) : base(materialService)
        { }
    }
}
