using Furny.Common.ServiceInterfaces;
using Furny.Common.ViewModels;
using Furny.Model;
using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.PanelCutterFeature.ServiceInterfaces
{
    public interface IPanelCutterService : IBaseService<PanelCutter>
    {
        Task<PanelCutterProfileViewModel> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<PanelCutterProfileCommand> jsonPatch, string id);

        Task<IList<AdViewModel>> GetAdsByCountry(string country);
    }
}
