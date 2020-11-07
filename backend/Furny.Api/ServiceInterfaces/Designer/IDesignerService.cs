using Furny.Data;
using Furny.Data.Designer;
using Furny.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IDesignerService : IBaseService<Designer>
    {
        Task<DesignerProfileCommand> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileCommand> jsonPatch, string id);

        Task<DesignerHomeCommand> GetAdsAsync(string id);

        Task AddFavoritePanelCutterAsync(string id, string pid);

        Task RemoveFavoritePanelCutterAsync(string id, string pid);
    }
}
