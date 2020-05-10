using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerModulController : ControllerBase
    {
        private readonly IModulService _modulService;

        public DesignerModulController(IModulService modulService)
        {
            _modulService = modulService;
        }
        
        [HttpPost("{id}/modules")]
        public async Task<IActionResult> Post(ModulDto modul, string id)
        {
            await _modulService.CreateAsync(modul, id);
            return Ok();
        }

        [HttpGet("{id}/modules")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _modulService.GetAsync(id));
        }

        [HttpGet("{id}/modules/{mid}")]
        public async Task<IActionResult> Get(string id, string mid)
        {
            return Ok(await _modulService.GetByIdAsync(id, mid));
        }

        [HttpDelete("{id}/modules/{mid}")]
        public async Task<IActionResult> Delete(string id, string mid)
        {
            await _modulService.RemoveAsync(id, mid);
            return Ok();
        }

        [HttpPost("{id}/modules/{mid}/components")]
        public async Task<IActionResult> AddComponent(ComponentDto component, string id, string mid)
        {
            await _modulService.AddComponentAsync(component, id, mid);
            return Ok();
        }

        [HttpDelete("{id}/modules/{mid}/components/{cid}")]
        public async Task<IActionResult> RemoveComponent( string id, string mid, string cid)
        {
            await _modulService.RemoveComponentAsync(id, mid, cid);
            return Ok();
        }

        [HttpPost("{id}/modules/{mid}/components/{cid}")]
        public async Task<IActionResult> CopyComponent(string id, string mid, string cid)
        {
            await _modulService.CopyComponentAsync(id, mid, cid);
            return Ok();
        }
    }
}




        