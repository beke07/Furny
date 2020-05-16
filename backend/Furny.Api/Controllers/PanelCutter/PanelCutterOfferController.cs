using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterOfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public PanelCutterOfferController(
            IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("offers/{oid}")]
        public async Task<IActionResult> Post(PanelCutterFillOfferDto offerDto, string oid)
        {
            await _offerService.FillPanelCutterOfferAsync(offerDto, oid);
            return Ok();
        }

        [HttpGet("offers/{oid}")]
        public async Task<IActionResult> Get(string oid)
        {
            return Ok(await _offerService.GetPanelCutterOfferAsync(oid));
        }

        [HttpGet("{id}/offers")]
        public async Task<IActionResult> GetTable(string id)
        {
            return Ok(await _offerService.GetPanelCutterOfferTableAsync(id));
        }
    }
}