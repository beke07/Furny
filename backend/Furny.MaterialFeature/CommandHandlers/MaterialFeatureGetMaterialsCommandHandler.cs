using Furny.Common.CommandHandlers;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureGetMaterialsCommandHandler : GetSingleElementsCommandBaseHandler<MaterialFeatureGetMaterialsCommand, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    {
        public MaterialFeatureGetMaterialsCommandHandler(IMaterialService materialService) : base(materialService)
        { }
    }
}
