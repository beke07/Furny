﻿using Furny.OfferFeature.Commands;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ViewModels;
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

        [HttpGet("{id}/furnitures/{fid}/table-offers")]
        public async Task<IList<OfferFeatureDesignerOfferTableViewModel>> GetOffers(string id, string fid)
            => await SendAsync(OfferFeatureGetDesignerOfferTableCommand.Create(id, fid));
    }
}