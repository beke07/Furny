using Furny.Common.ServiceInterfaces;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ViewModels;

namespace Furny.MaterialFeature.ServiceInterfaces
{
    public interface IMaterialService : ISingleElementService<MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>
    { }
}
