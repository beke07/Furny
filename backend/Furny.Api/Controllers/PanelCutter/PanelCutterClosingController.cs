using Furny.ClosingFeature.Commands;
using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ViewModels;
using Furny.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterClosingController : MediatorControllerBase
    {
        public PanelCutterClosingController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/closings")]
        public async Task PostClosing(ClosingFeatureClosingDto closing, string id)
            => await SendAsync(ClosingFeatureCreateClosingCommand.Create(id, closing));

        [HttpGet("{id}/closings")]
        public async Task<IList<ClosingFeatureClosingTableViewModel>> GetClosings(string id)
            => await SendAsync(ClosingFeatureGetClosingsCommand.Create(id));

        [HttpGet("{id}/closings/{cid}")]
        public async Task<ClosingFeatureClosingDto> GetClosing(string id, string cid)
            => await SendAsync(ClosingFeatureGetClosingCommand.Create(id, cid));

        [HttpDelete("{id}/closings/{cid}")]
        public async Task DeleteClosing(string id, string cid)
            => await SendAsync(ClosingFeatureRemoveClosingCommand.Create(id, cid));

        [HttpPatch("{id}/closings/{cid}")]
        public async Task UpdateClosing([FromBody] JsonPatchDocument<ClosingFeatureClosingDto> jsonPatch, string id, string cid)
            => await SendAsync(ClosingFeatureUpdateClosingCommand.Create(jsonPatch, id, cid));
    }
}