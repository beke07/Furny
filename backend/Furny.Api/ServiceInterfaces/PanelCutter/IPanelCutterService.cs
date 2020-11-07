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
        Task<PanelCutterProfileCommand> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileCommand> jsonPatch, string id);

        Task<IList<DesignerAdCommand>> GetAdsByCountry(string country);
    }
}
