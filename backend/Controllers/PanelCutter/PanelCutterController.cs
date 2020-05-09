using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelCutterController : ControllerBase
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterController(
            IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetHome()
        //{

        //}
    }
}
