using Furny.Data;
using Furny.Data.Designer;
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

        Task<IList<DesignerAdDto>> GetAdsByCountry(string country);
    }
}
