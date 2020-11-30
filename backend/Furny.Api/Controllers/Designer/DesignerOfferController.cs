using Furny.OfferFeature.Commands;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ViewModels;
using Furny.OrderFeature.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerOfferController : MediatorControllerBase
    {
        public DesignerOfferController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/furnitures/{fid}/offers")]
        public async Task Post(OfferFeatureOfferDto offer, string id, string fid)
            => await SendAsync(OfferFeatureCreateOfferCommand.Create(offer, id, fid));

        [HttpGet("{id}/furnitures/{fid}/offers")]
        public async Task<IList<OfferFeatureOfferDto>> Get(string id, string fid)
            => await SendAsync(OfferFeatureGetDesignerOffersCommand.Create(id, fid));

        [HttpGet("{id}/offers")]
        public async Task<IList<OfferFeatureDesignerOfferTableViewModel>> GetOffers(string id)
            => await SendAsync(OfferFeatureGetDesignerOfferTableCommand.Create(id));

        [HttpPost("offers/{id}/accept")]
        public async Task Accept(OrderFeatureOrderFillDto fillDto, string id)
            => await SendAsync(OfferFeatureAcceptOfferCommand.Create(id, fillDto));

        [HttpPost("offers/{id}/decline")]
        public async Task Decline(string id)
            => await SendAsync(OfferFeatureDeclineOfferCommand.Create(id));
    }
}
