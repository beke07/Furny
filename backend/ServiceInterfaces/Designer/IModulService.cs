using Furny.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IModulService : ISingleElementService<ModulDto, ModulTableDto>
    {
        Task AddComponentAsync(ComponentDto component, string id, string mid);

        Task CopyComponentAsync(string cid, string id, string mid);

        Task RemoveComponentAsync(string cid, string id, string mid);
    }
}
