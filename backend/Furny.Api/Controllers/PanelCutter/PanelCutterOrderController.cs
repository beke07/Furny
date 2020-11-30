using Furny.OrderFeature.Commands;
using Furny.OrderFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterOrderController : MediatorControllerBase
    {
        public PanelCutterOrderController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/orders")]
        public async Task<IList<OrderFeaturePanelCutterTableViewModel>> GetPanelCutterOffers(string id)
            => await SendAsync(OrderFeatureGetPanelCutterOrdersCommand.Create(id));

    }
}