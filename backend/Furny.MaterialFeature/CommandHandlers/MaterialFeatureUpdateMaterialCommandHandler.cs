using Furny.Common.CommandHandlers;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureUpdateMaterialCommandHandler : UpdateSingleElementCommandBaseHandler<MaterialFeatureUpdateMaterialCommand, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    {
        public MaterialFeatureUpdateMaterialCommandHandler(IMaterialService materialService) : base(materialService)
        { }
    }
}
