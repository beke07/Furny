using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerProfileController : ControllerBase
    {
        private readonly IDesignerService _designerService;


        public DesignerProfileController(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(string id)
        {
            return Ok(await _designerService.GetProfileAsync(id));
        }

        [HttpPatch("{id}/profile")]
        public async Task<IActionResult> PatchProfile([FromBody]JsonPatchDocument<DesignerProfileDto> jsonPatch, string id)
        {
            await _designerService.UpdateProfileAsync(jsonPatch, id);
            return Ok();
        }
    }
}
