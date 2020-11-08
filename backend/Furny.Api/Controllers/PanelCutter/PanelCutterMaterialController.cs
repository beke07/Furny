using Furny.MaterialFeature.Commands;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ViewModels;
using Furny.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterMaterialController : MediatorControllerBase
    {
        public PanelCutterMaterialController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/materials")]
        public async Task PostMaterial(MaterialFeatureMaterialDto material, string id)
            => await SendAsync(MaterialFeatureCreateMaterialCommand.Create(id, material));

        [HttpGet("{id}/materials")]
        public async Task<IList<MaterialFeatureMaterialTableViewModel>> GetMaterials(string id)
            => await SendAsync(MaterialFeatureGetMaterialsCommand.Create(id));

        [HttpGet("{id}/materials/{mid}")]
        public async Task<MaterialFeatureMaterialDto> GetMaterial(string id, string mid)
            => await SendAsync(MaterialFeatureGetMaterialCommand.Create(id, mid));

        [HttpDelete("{id}/materials/{mid}")]
        public async Task DeleteMaterial(string id, string mid)
            => await SendAsync(MaterialFeatureRemoveMaterialCommand.Create(id, mid));

        [HttpPatch("{id}/materials/{mid}")]
        public async Task UpdateMaterial([FromBody] JsonPatchDocument<MaterialFeatureMaterialDto> jsonPatch, string id, string mid)
            => await SendAsync(MaterialFeatureUpdateMaterialCommand.Create(jsonPatch, id, mid));
    }
}