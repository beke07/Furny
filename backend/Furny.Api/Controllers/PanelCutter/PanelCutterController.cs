using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterController : MediatorControllerBase
    {
        public PanelCutterController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}")]
        public async Task<PanelCutterHomeViewModel> Get(string id)
            => await SendAsync(PanelCutterGetCommand.Create(id));
    }
}
