using Furny.Common.ServiceInterfaces;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ViewModels;
using System.Threading.Tasks;

namespace Furny.ModulFeature.ServiceInterfaces
{
    public interface IModulService : ISingleElementService<ModulModulDto, ModulTableViewModel>
    {
        Task AddComponentAsync(ModulComponentDto component, string id, string mid);

        Task CopyComponentAsync(string id, string mid, string cid);

        Task RemoveComponentAsync(string id, string mid, string cid);
    }
}
