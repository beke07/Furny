using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterProfileController : ControllerBase
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterProfileController(
            IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

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
    }
}
