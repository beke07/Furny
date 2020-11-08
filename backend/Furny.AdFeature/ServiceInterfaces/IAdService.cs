using Furny.AdFeature.Data;
using Furny.AdFeature.ViewModels;
using Furny.Common.ServiceInterfaces;

namespace Furny.AdFeature.ServiceInterfaces
{
    public interface IAdService : ISingleElementService<AdFeatureAdDto, AdFeatureAdTableViewModel>
    { }
}
