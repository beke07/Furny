using Furny.Data;
using Furny.Data.Designer;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Conventions;
using System.IO;
using System.Threading.Tasks;
using static Furny.Common.Enums;

namespace Furny.Controllers
{
    [Route("api/designer")]
    [ApiController]
    public class DesignerFurnitureController : ControllerBase
    {
        private readonly IFurnitureService _furnitureService;

        public DesignerFurnitureController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        [HttpGet("{id}/furnitures")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _furnitureService.GetAsync(id));
        }

        [HttpGet("{id}/furnitures/{fid}")]
        public async Task<IActionResult> GetById(string id, string fid)
        {
            return Ok(await _furnitureService.GetByIdAsync(id, fid));
        }

        [HttpPatch("{id}/furnitures/{fid}")]
        public async Task<IActionResult> Patch(JsonPatchDocument<FurnitureDto> jsonPatch, string id, string fid)
        {
            await _furnitureService.UpdateAsync(jsonPatch, id, fid);
            return Ok();
        }

        [HttpPost("{id}/furnitures")]
        public async Task<IActionResult> GetById(FurnitureDto furniture, string id)
        {
            await _furnitureService.CreateAsync(furniture, id);
            return Ok();
        }

        [HttpPost("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task<IActionResult> AddModul(string id, string fid, string mid)
        {
            await _furnitureService.AddModulAsync(id, fid, mid);
            return Ok();
        }

        [HttpDelete("{id}/furnitures/{fid}/modules/{mid}")]
        public async Task<IActionResult> RemoveModul(string id, string fid, string mid)
        {
            await _furnitureService.RemoveModulAsync(id, fid, mid);
            return Ok();
        }

        [HttpPost("{id}/furnitures/{fid}/components")]
        public async Task<IActionResult> AddComponent(ComponentDto component, string id, string fid)
        {
            await _furnitureService.AddComponentAsync(component, id, fid);
            return Ok();
        }

        [HttpDelete("{id}/furnitures/{fid}/components/{cid}")]
        public async Task<IActionResult> RemoveComponent(string id, string fid, string cid)
        {
            await _furnitureService.RemoveComponentAsync(id, fid, cid);
            return Ok();
        }

        [HttpGet("{id}/furnitures/{fid}/export")]
        public async Task<FileStreamResult> Excel([FromQuery]ExcelType excelType, string id, string fid)
        {
            var result = await _furnitureService.ExportAsync(excelType, id, fid);

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return new FileStreamResult(result.Item1, contentType)
            {
                FileDownloadName = Path.GetFileName(result.Item2)
            };
        }
    }
}
