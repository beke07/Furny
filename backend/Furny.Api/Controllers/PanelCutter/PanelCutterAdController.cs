using Furny.AdFeature.Commands;
using Furny.AdFeature.Data;
using Furny.AdFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterAdController : MediatorControllerBase
    {
        public PanelCutterAdController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/ads")]
        public async Task PostAd(AdFeatureAdDto ad, string id)
            => await SendAsync(AdFeatureCreateAdCommand.Create(id, ad));

        [HttpGet("{id}/ads")]
        public async Task<IList<AdFeatureAdTableViewModel>> GetAds(string id)
            => await SendAsync(AdFeatureGetAdsCommand.Create(id));

        [HttpGet("{id}/ads/{adId}")]
        public async Task<AdFeatureAdDto> GetAd(string id, string adId)
            => await SendAsync(AdFeatureGetAdCommand.Create(id, adId));

        [HttpDelete("{id}/ads/{adId}")]
        public async Task DeleteAd(string id, string adId)
            => await SendAsync(AdFeatureRemoveAdCommand.Create(id, adId));

        [HttpPatch("{id}/ads/{adId}")]
        public async Task UpdateAd([FromBody] JsonPatchDocument<AdFeatureAdDto> jsonPatch, string id, string adId)
            => await SendAsync(AdFeatureUpdateAdCommand.Create(jsonPatch, id, adId));
    }
}
