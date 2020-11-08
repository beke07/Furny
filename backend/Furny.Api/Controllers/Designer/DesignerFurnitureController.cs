using Furny.Common.Enums;
using Furny.DesignerFurnitureFeature.Commands;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerFurnitureController : MediatorControllerBase
    {
        public DesignerFurnitureController(
            IMediator mediator) : base(mediator)
        { }

        [HttpGet("{id}/furnitures")]
        public async Task<IList<DesignerFurnitureFurnitureTableViewModel>> Get(string id)
            => await SendAsync(DesignerFurnitureGetFurnituresCommand.Create(id));

        [HttpGet("{id}/furnitures/{fid}")]
        public async Task<DesignerFurnitureFurnitureDto> GetById(string id, string fid)
            => await SendAsync(DesignerFurnitureGetFurnitureCommand.Create(id, fid));

        [HttpPatch("{id}/furnitures/{fid}")]
        public async Task Patch(JsonPatchDocument<DesignerFurnitureFurnitureDto> jsonPatch, string id, string fid)
            => await SendAsync(DesignerFurnitureUpdateFurnitureCommand.Create(jsonPatch, id, fid));

        [HttpPost("{id}/furnitures")]
        public async Task Post(DesignerFurnitureFurnitureDto furniture, string id)
            => await SendAsync(DesignerFurnitureCreateFurnitureCommand.Create(id, furniture));

        [HttpPost("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task AddModul(string id, string fid, string mid)
            => await SendAsync(DesignerFurnitureAddModulCommand.Create(id, fid, mid));

        [HttpDelete("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task RemoveModul(string id, string fid, string mid)
            => await SendAsync(DesignerFurnitureRemoveModulCommand.Create(id, fid, mid));

        [HttpPost("{id}/furnitures/{fid}/components")]
        public async Task AddComponent(DesignerFurnitureComponentDto component, string id, string fid)
            => await SendAsync(DesignerFurnitureAddComponentCommand.Create(id, fid, component));

        [HttpDelete("{id}/furnitures/{fid}/components/{cid}")]
        public async Task RemoveComponent(string id, string fid, string cid)
            => await SendAsync(DesignerFurnitureRemoveComponentCommand.Create(id, fid, cid));

        [HttpGet("{id}/furnitures/{fid}/export")]
        public async Task<FileStreamResult> Excel([FromQuery] ExcelType excelType, string id, string fid)
            => await SendAsync(DesignerFurnitureExportCommand.Create(excelType, id, fid));
    }
}
