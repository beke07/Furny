using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterClosingController : ControllerBase
    {
        private readonly IClosingService _closingService;

        public PanelCutterClosingController(
            IClosingService closingService)
        {
            _closingService = closingService;
        }

        [HttpPost("{id}/closings")]
        public async Task<IActionResult> PostMaterial(ClosingDto closing, string id)
        {
            await _closingService.CreateAsync(closing, id);
            return Ok();
        }

        [HttpGet("{id}/closings")]
        public async Task<IActionResult> GetClosings(string id)
        {
            return Ok(await _closingService.GetAsync(id));
        }

        [HttpGet("{id}/closings/{cid}")]
        public async Task<IActionResult> GetClosing(string id, string cid)
        {
            return Ok(await _closingService.GetByIdAsync(id, cid));
        }

        [HttpDelete("{id}/closings/{cid}")]
        public async Task<IActionResult> DeleteClosing(string id, string cid)
        {
            await _closingService.RemoveAsync(id, cid);
            return Ok();
        }

        [HttpPatch("{id}/closings/{cid}")]
        public async Task<IActionResult> UpdateClosing([FromBody]JsonPatchDocument<ClosingDto> jsonPatch, string id, string cid)
        {
            await _closingService.UpdateAsync(jsonPatch, id, cid);
            return Ok();
        }
    }
}