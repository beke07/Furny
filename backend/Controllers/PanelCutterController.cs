using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelCutterController : ControllerBase
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterController(
            IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetHome()
        //{

        //}

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(string id)
        {
            return Ok(await _panelCutterService.GetProfileAsync(id));
        }

        [HttpPatch("{id}/profile")]
        public async Task<IActionResult> PatchProfile([FromBody]JsonPatchDocument<PanelCutterProfileDto> jsonPatch, string id)
        {
            await _panelCutterService.UpdateProfileAsync(jsonPatch, id);
            return Ok();
        }

        [HttpPost("{id}/materials")]
        public async Task<IActionResult> PostMaterial(MaterialDto material, string id)
        {
            await _panelCutterService.CreateMaterialAsync(material, id);
            return Ok();
        }

        [HttpGet("{id}/materials")]
        public async Task<IActionResult> GetMaterials(string id)
        {
            return Ok(await _panelCutterService.GetMaterialsAsync(id));
        }

        [HttpGet("{id}/materials/{mid}")]
        public async Task<IActionResult> GetMaterial(string id, string mid)
        {
            return Ok(await _panelCutterService.GetMaterialAsync(id, mid));
        }

        [HttpDelete("{id}/materials/{mid}")]
        public async Task<IActionResult> DeleteMaterial(string id, string mid)
        {
            await _panelCutterService.RemoveMaterialAsync(id, mid);
            return Ok();
        }

        [HttpPatch("{id}/materials/{mid}")]
        public async Task<IActionResult> DeleteMaterial([FromBody]JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid)
        {
            await _panelCutterService.UpdateMaterialAsync(jsonPatch, id, mid);
            return Ok();
        }
    }
}
