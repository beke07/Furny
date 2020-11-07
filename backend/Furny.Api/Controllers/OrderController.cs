using Furny.Data;
using Furny.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class OrderController : MediatorControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService,
            IMediator mediator) : base(mediator)
        {
            _orderService = orderService;
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpGet("designers/{id}/orders")]
        public async Task<IActionResult> GetDesignerOffers(string id)
        {
            return Ok(await _orderService.GetDesignerOrdersAsnyc(id));
        }

        [HttpGet("panelcutter/{id}/orders")]
        public async Task<IActionResult> GetPanelCutterOffers(string id)
        {
            return Ok(await _orderService.GetPanelOrdersAsnyc(id));
        }

        [HttpPost("orders/{oid}/accept")]
        public async Task<IActionResult> AcceptOrder(OrderFillCommand orderDto, string oid)
        {
            await _orderService.AcceptAsnyc(oid, orderDto);
            return Ok();
        }

        [HttpPost("orders/{oid}/decline")]
        public async Task<IActionResult> DeclineOrder(string oid)
        {
            await _orderService.DeclineAsnyc(oid);
            return Ok();
        }

        [HttpPost("orders/{oid}/done")]
        public async Task<IActionResult> DoneOrder(string oid)
        {
            await _orderService.DoneAsnyc(oid);
            return Ok();
        }
    }
}
