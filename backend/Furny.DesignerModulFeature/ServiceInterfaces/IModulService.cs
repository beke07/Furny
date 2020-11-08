using Furny.Common.ServiceInterfaces;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ViewModels;
using System.Threading.Tasks;

namespace Furny.DesignerModulFeature.ServiceInterfaces
{
    public interface IModulService : ISingleElementService<DesignerModulModulDto, DesignerModulModulTableViewModel>
    {
        Task AddComponentAsync(DesignerModulComponentDto component, string id, string mid);

        Task CopyComponentAsync(string id, string mid, string cid);

        Task RemoveComponentAsync(string id, string mid, string cid);
    }
}
