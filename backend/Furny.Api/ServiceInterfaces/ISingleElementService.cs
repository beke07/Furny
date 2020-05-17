using Furny.Data;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface ISingleElementService<D, TD>
        where D : class
        where TD : TableDtoBase
    {
        Task CreateAsync(D element, string baseElementId);

        Task<IList<TD>> GetAsync(string baseElementId);

        Task<IList<TD>> QuickSearchAsync(string baseElementId, string term, string propertyName);

        Task<D> GetByIdAsync(string baseElementId, string elementId);

        Task UpdateAsync(JsonPatchDocument<D> jsonPatch, string baseElementId, string elementId);

        Task RemoveAsync(string baseElementId, string elementId);
    }
}
