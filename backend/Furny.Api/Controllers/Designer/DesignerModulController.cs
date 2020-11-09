using Furny.Model;
using Furny.ModulFeature.Commands;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class ModulController : MediatorControllerBase
    {
        public ModulController(IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/modules/quick-search/{term}")]
        public async Task<IList<ModulTableViewModel>> QuickSearch(string id, string term)
            => await SendAsync(ModulSearchModulCommand.Create(id, term, nameof(Modul.Name)));

        [HttpPost("{id}/modules")]
        public async Task Post(ModulModulDto modul, string id)
            => await SendAsync(ModulCreateModulCommand.Create(id, modul));

        [HttpGet("{id}/modules")]
        public async Task<IList<ModulTableViewModel>> Get(string id)
            => await SendAsync(ModulGetModulsCommand.Create(id));

        [HttpGet("{id}/modules/{mid}")]
        public async Task<ModulModulDto> Get(string id, string mid)
            => await SendAsync(ModulGetModulCommand.Create(id, mid));

        [HttpPatch("{id}/modules/{mid}")]
        public async Task Patch(JsonPatchDocument<ModulModulDto> jsonPatch, string id, string mid)
            => await SendAsync(ModulUpdateModulCommand.Create(jsonPatch, id, mid));

        [HttpDelete("{id}/modules/{mid}")]
        public async Task Delete(string id, string mid)
            => await SendAsync(ModulRemoveModulCommand.Create(id, mid));

        [HttpPost("{id}/modules/{mid}/components")]
        public async Task AddComponent(ModulComponentDto component, string id, string mid)
            => await SendAsync(ModulAddComponentCommand.Create(component, id, mid));

        [HttpDelete("{id}/modules/{mid}/components/{cid}")]
        public async Task RemoveComponent(string id, string mid, string cid)
            => await SendAsync(ModulRemoveComponentCommand.Create(id, mid, cid));

        [HttpPost("{id}/modules/{mid}/components/{cid}")]
        public async Task CopyComponent(string id, string mid, string cid)
            => await SendAsync(ModulCopyComponentCommand.Create(id, mid, cid));
    }
}




