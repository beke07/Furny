using Furny.Common.CommandHandlers;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureCreateMaterialCommandHandler : CreateSingleElementCommandBaseHandler<MaterialFeatureCreateMaterialCommand, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    {
        public MaterialFeatureCreateMaterialCommandHandler(IMaterialService closingService) : base(closingService)
        { }
    }
}
