using Furny.OfferFeature.Commands;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterOfferController : MediatorControllerBase
    {
        public PanelCutterOfferController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/offers/{oid}")]
        public async Task Post(OfferFeaturePanelCutterFillOfferDto fillDto, string oid)
            => await SendAsync(OfferFeatureGetPanelCutterFillOfferCommand.Create(oid, fillDto));

        [HttpGet("{id}/offers/{oid}")]
        public async Task<OfferFeaturePanelCutterOfferDto> Get(string oid)
            => await SendAsync(OfferFeatureGetPanelCutterOfferCommand.Create(oid));

        [HttpGet("{id}/offers")]
        public async Task<IList<OfferFeaturePanelCutterOfferTableViewModel>> GetTable(string id)
            => await SendAsync(OfferFeatureGetPanelCutterOfferTableCommand.Create(id));
    }
}