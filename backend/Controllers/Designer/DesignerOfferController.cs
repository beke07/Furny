using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerOfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public DesignerOfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("{id}/furnitures/{fid}/offers")]
        public async Task<IActionResult> Post(OfferDto offer, string id, string fid)
        {
            await _offerService.CreateAsnyc(offer, id, fid);
            return Ok();
        }

        [HttpGet("{id}/furnitures/{fid}/offers")]
        public async Task<IActionResult> Get(string id, string fid)
        {
            return Ok(await _offerService.GetDesignerOffersAsnyc(id, fid));
        }

        [HttpGet("{id}/furnitures/{fid}/table-offers")]
        public async Task<IActionResult> GetOffers(string id, string fid)
        {
            return Ok(await _offerService.GetDesignerOfferTableAsnyc(id, fid));
        }
    }
}
