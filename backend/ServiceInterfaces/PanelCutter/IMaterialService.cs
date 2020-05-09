using Furny.Data;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IMaterialService
    {
        Task CreateAsync(MaterialDto material, string id);

        Task<MaterialDto> GetAsync(string id, string mid);

        Task RemoveAsync(string id, string mid);

        Task<IList<MaterialTableDto>> GetAsync(string id);

        Task UpdateAsync(JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid);
    }
}
