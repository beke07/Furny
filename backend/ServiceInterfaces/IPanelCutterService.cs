using Furny.Data;
using Furny.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IPanelCutterService : IBaseService<PanelCutter>
    {
        Task<PanelCutterProfileDto> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileDto> jsonPatch, string id);

        Task CreateMaterialAsync(MaterialDto material, string id);

        Task<MaterialDto> GetMaterialAsync(string id, string mid);

        Task RemoveMaterialAsync(string id, string mid);

        Task<IList<MaterialTableDto>> GetMaterialsAsync(string id);

        Task UpdateMaterialAsync(JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid);
    }
}
