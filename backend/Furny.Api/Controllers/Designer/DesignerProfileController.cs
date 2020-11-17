﻿using Furny.DesignerFeature.Commands;
using Furny.DesignerFeature.Data;
using Furny.DesignerFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerProfileController : MediatorControllerBase
    {
        public DesignerProfileController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("profile")]
        public async Task<DesignerProfileViewModel> GetProfile([FromQuery]string id, [FromQuery] string email)
            => await SendAsync(DesignerGetProfileCommand.Create(id, email));

        [HttpPatch("{id}/profile")]
        public async Task PatchProfile([FromBody] JsonPatchDocument<DesignerProfileDto> jsonPatch, string id)
            => await SendAsync(DesignerUpdateProfileCommand.Create(jsonPatch, id));
    }
}
