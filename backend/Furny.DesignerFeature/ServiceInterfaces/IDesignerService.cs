using Furny.Common.ServiceInterfaces;
using Furny.DesignerFeature.Data;
using Furny.DesignerFeature.ViewModels;
using Furny.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.ServiceInterfaces
{
    public interface IDesignerService : IBaseService<Designer>
    {
        Task<DesignerProfileViewModel> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileDto> jsonPatch, string id);

        Task<DesignerHomeViewModel> GetAdsAsync(string id);

        Task AddFavoritePanelCutterAsync(string id, string pid);

        Task RemoveFavoritePanelCutterAsync(string id, string pid);
    }
}
