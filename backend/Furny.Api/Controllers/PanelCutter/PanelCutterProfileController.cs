using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.Data;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/panelCutter")]
    [ApiController]
    public class PanelCutterProfileController : MediatorControllerBase
    {
        public PanelCutterProfileController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("profile")]
        public async Task<PanelCutterProfileViewModel> GetProfile([FromQuery]string id, [FromQuery] string email)
            => await SendAsync(PanelCutterGetProfileCommand.Create(id, email)); 

        [HttpPatch("{id}/profile")]
        public async Task PatchProfile([FromBody] JsonPatchDocument<PanelCutterProfileDto> jsonPatch, string id)
            => await SendAsync(PanelCutterUpdateProfileCommand.Create(jsonPatch, id));
    }
}
