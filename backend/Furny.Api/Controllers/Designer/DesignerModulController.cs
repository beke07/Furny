using Furny.DesignerModulFeature.Commands;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ViewModels;
using Furny.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerModulController : MediatorControllerBase
    {
        public DesignerModulController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/modules/quick-search/{term}")]
        public async Task<IList<DesignerModulModulTableViewModel>> QuickSearch(string id, string term)
            => await SendAsync(DesignerModulSearchModulCommand.Create(id, term, nameof(Modul.Name)));

        [HttpPost("{id}/modules")]
        public async Task Post(DesignerModulModulDto modul, string id)
            => await SendAsync(DesignerModulCreateModulCommand.Create(id, modul));

        [HttpGet("{id}/modules")]
        public async Task<IList<DesignerModulModulTableViewModel>> Get(string id)
            => await SendAsync(DesignerModulGetModulsCommand.Create(id));

        [HttpGet("{id}/modules/{mid}")]
        public async Task<DesignerModulModulDto> Get(string id, string mid)
            => await SendAsync(DesignerModulGetModulCommand.Create(id, mid));

        [HttpPatch("{id}/modules/{mid}")]
        public async Task Patch(JsonPatchDocument<DesignerModulModulDto> jsonPatch, string id, string mid)
            => await SendAsync(DesignerModulUpdateModulCommand.Create(jsonPatch, id, mid));

        [HttpDelete("{id}/modules/{mid}")]
        public async Task Delete(string id, string mid)
            => await SendAsync(DesignerModulRemoveModulCommand.Create(id, mid));

        [HttpPost("{id}/modules/{mid}/components")]
        public async Task AddComponent(DesignerModulComponentDto component, string id, string mid)
            => await SendAsync(DesignerModulAddComponentCommand.Create(component, id, mid));

        [HttpDelete("{id}/modules/{mid}/components/{cid}")]
        public async Task RemoveComponent(string id, string mid, string cid)
            => await SendAsync(DesignerModulRemoveComponentCommand.Create(id, mid, cid));

        [HttpPost("{id}/modules/{mid}/components/{cid}")]
        public async Task CopyComponent(string id, string mid, string cid)
            => await SendAsync(DesignerModulCopyComponentCommand.Create(id, mid, cid));
    }
}




