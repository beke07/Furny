using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterMaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public PanelCutterMaterialController(
            IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost("{id}/materials")]
        public async Task<IActionResult> PostMaterial(MaterialDto material, string id)
        {
            await _materialService.CreateAsync(material, id);
            return Ok();
        }

        [HttpGet("{id}/materials")]
        public async Task<IActionResult> GetMaterials(string id)
        {
            return Ok(await _materialService.GetAsync(id));
        }

        [HttpGet("{id}/materials/{mid}")]
        public async Task<IActionResult> GetMaterial(string id, string mid)
        {
            return Ok(await _materialService.GetAsync(id, mid));
        }

        [HttpDelete("{id}/materials/{mid}")]
        public async Task<IActionResult> DeleteMaterial(string id, string mid)
        {
            await _materialService.RemoveAsync(id, mid);
            return Ok();
        }

        [HttpPatch("{id}/materials/{mid}")]
        public async Task<IActionResult> DeleteMaterial([FromBody]JsonPatchDocument<MaterialDto> jsonPatch, string id, string mid)
        {
            await _materialService.UpdateAsync(jsonPatch, id, mid);
            return Ok();
        }
    }
}