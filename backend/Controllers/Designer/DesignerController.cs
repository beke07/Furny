using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerController : ControllerBase
    {
        private readonly IDesignerService _designerService;


        public DesignerController(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _designerService.GetAdsAsync(id));
        }
    }
}
