using Furny.Data;
using Furny.Data.Designer;
using Furny.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IDesignerService : IBaseService<Designer>
    {
        Task<DesignerProfileDto> GetProfileAsync(string id);

        Task UpdateProfileAsync(JsonPatchDocument<DesignerProfileDto> jsonPatch, string id);

        Task<DesignerHomeDto> GetAdsAsync(string id);
    }
}
