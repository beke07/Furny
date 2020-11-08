using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.ServiceInterfaces;

namespace Furny.ClosingFeature.ServiceInterfaces
{
    public interface IClosingService : ISingleElementService<ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>
    { }
}
