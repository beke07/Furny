using Furny.OrderFeature.Commands;
using Furny.OrderFeature.Data;
using Furny.OrderFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : MediatorControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}")]
        public async Task<OrderFeatureOrderViewModel> GetById(string id)
            => await SendAsync(OrderFeatureGetOrderCommand.Create(id));

        [HttpPost("{id}/done")]
        public async Task DoneOrder(string id)
            => await SendAsync(OrderFeatureDoneOrderCommand.Create(id));
    }
}
