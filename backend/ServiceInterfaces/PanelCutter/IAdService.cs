using Furny.Data;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAdService
    {
        Task CreateAsync(AdDto ad, string id);

        Task<IList<AdDto>> GetAsync(string id);

        Task UpdateAsync(JsonPatchDocument<AdDto> jsonPatch, string id, string adId);

        Task RemoveAsync(string id, string adId);
    }
}
