using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("offers/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpGet("desginers/{id}/offers")]
        public async Task<IActionResult> GetDesignerOffers(string id)
        {
            return Ok(await _orderService.GetDesignerOrdersAsnyc(id));
        }

        [HttpGet("panelcutter/{id}/offers")]
        public async Task<IActionResult> GetPanelCutterOffers(string id)
        {
            return Ok(await _orderService.GetPanelOrdersAsnyc(id));
        }

        [HttpPost("desginers/{id}/offers/{oid}/accept")]
        public async Task<IActionResult> AcceptOrder(OrderFillDto orderDto, string id)
        {
            await _orderService.AcceptAsnyc(id, orderDto);
            return Ok();
        }

        [HttpPost("desginers/{id}/offers/{oid}/decline")]
        public async Task<IActionResult> DeclineOrder(string id)
        {
            await _orderService.DeclineAsnyc(id);
            return Ok();
        }

        [HttpPost("panelcutter/{id}/offers/{oid}/done")]
        public async Task<IActionResult> DoneOrder(string id)
        {
            await _orderService.DoneAsnyc(id);
            return Ok();
        }
    }
}
