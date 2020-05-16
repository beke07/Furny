using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterController : ControllerBase
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterController(
            IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }
    }
}
