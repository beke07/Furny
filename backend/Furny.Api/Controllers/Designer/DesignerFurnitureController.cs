using Furny.Common.Enums;
using Furny.FurnitureFeature.Commands;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class FurnitureController : MediatorControllerBase
    {
        public FurnitureController(
            IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/furnitures")]
        public async Task<IList<FurnitureFurnitureTableViewModel>> Get(string id)
            => await SendAsync(FurnitureGetFurnituresCommand.Create(id));

        [HttpGet("{id}/furnitures/{fid}")]
        public async Task<FurnitureFurnitureDto> GetById(string id, string fid)
            => await SendAsync(FurnitureGetFurnitureCommand.Create(id, fid));

        [HttpPatch("{id}/furnitures/{fid}")]
        public async Task Patch(JsonPatchDocument<FurnitureFurnitureDto> jsonPatch, string id, string fid)
            => await SendAsync(FurnitureUpdateFurnitureCommand.Create(jsonPatch, id, fid));

        [HttpPost("{id}/furnitures")]
        public async Task Post(FurnitureFurnitureDto furniture, string id)
            => await SendAsync(FurnitureCreateFurnitureCommand.Create(id, furniture));

        [HttpPost("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task AddModul(string id, string fid, string mid)
            => await SendAsync(FurnitureAddModulCommand.Create(id, fid, mid));

        [HttpDelete("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task RemoveModul(string id, string fid, string mid)
            => await SendAsync(FurnitureRemoveModulCommand.Create(id, fid, mid));

        [HttpPost("{id}/furnitures/{fid}/components")]
        public async Task AddComponent(FurnitureComponentDto component, string id, string fid)
            => await SendAsync(FurnitureAddComponentCommand.Create(id, fid, component));

        [HttpDelete("{id}/furnitures/{fid}/components/{cid}")]
        public async Task RemoveComponent(string id, string fid, string cid)
            => await SendAsync(FurnitureRemoveComponentCommand.Create(id, fid, cid));

        [HttpGet("{id}/furnitures/{fid}/export")]
        public async Task<FileStreamResult> Excel([FromQuery] ExcelType excelType, string id, string fid)
            => await SendAsync(FurnitureExportCommand.Create(excelType, id, fid));
    }
}
