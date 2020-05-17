using Furny.Data;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IModulService : ISingleElementService<ModulDto, ModulTableDto>
    {
        Task AddComponentAsync(ComponentDto component, string id, string mid);

        Task CopyComponentAsync(string id, string mid, string cid);

        Task RemoveComponentAsync(string id, string mid, string cid);
    }
}
