using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterAdController : ControllerBase
    {
        private readonly IAdService _adService;

        public PanelCutterAdController(
            IAdService adService)
        {
            _adService = adService;
        }

        [HttpPost("{id}/ads")]
        public async Task<IActionResult> PostAd(AdDto ad, string id)
        {
            await _adService.CreateAsync(ad, id);
            return Ok();
        }

        [HttpGet("{id}/ads")]
        public async Task<IActionResult> GetAds(string id)
        {
            return Ok(await _adService.GetAsync(id));
        }

        [HttpDelete("{id}/ads/{adId}")]
        public async Task<IActionResult> DeleteAd(string id, string adId)
        {
            await _adService.RemoveAsync(id, adId);
            return Ok();
        }

        [HttpPatch("{id}/ads/{adId}")]
        public async Task<IActionResult> DeleteAd([FromBody]JsonPatchDocument<AdDto> jsonPatch, string id, string adId)
        {
            await _adService.UpdateAsync(jsonPatch, id, adId);
            return Ok();
        }
    }
}
