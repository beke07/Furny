using Furny.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerController : MediatorControllerBase
    {
        private readonly IDesignerService _designerService;

        public DesignerController(
            IDesignerService designerService,
            IMediator mediator) : base(mediator)
        {
            _designerService = designerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _designerService.GetAdsAsync(id));
        }

        [HttpGet("{id}/favorites/{pid}")]
        public async Task<IActionResult> AddFavoritePanelCutter(string id, string pid)
        {
            await _designerService.AddFavoritePanelCutterAsync(id, pid);
            return Ok();
        }

        [HttpDelete("{id}/favorites/{pid}")]
        public async Task<IActionResult> RemoveFavoritePanelCutter(string id, string pid)
        {
            await _designerService.RemoveFavoritePanelCutterAsync(id, pid);
            return Ok();
        }
    }
}
