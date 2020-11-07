using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterController : MediatorControllerBase
    {
        public PanelCutterController(IMediator mediator) : base(mediator)
        { }
    }
}
