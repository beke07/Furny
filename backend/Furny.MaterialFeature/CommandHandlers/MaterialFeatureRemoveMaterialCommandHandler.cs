using Furny.Common.CommandHandlers;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureRemoveMaterialCommandHandler : RemoveSingleElementCommandBaseHandler<MaterialFeatureRemoveMaterialCommand, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    {
        public MaterialFeatureRemoveMaterialCommandHandler(IMaterialService materialService) : base(materialService)
        { }
    }
}
