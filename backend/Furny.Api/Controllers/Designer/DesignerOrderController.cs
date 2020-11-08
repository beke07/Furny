using Furny.OrderFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerOrderController : MediatorControllerBase
    {
        public DesignerOrderController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/orders")]
        public async Task GetOffers(string id)
            => await SendAsync(OrderFeatureGetDesignerOrdersCommand.Create(id));
    }
}
