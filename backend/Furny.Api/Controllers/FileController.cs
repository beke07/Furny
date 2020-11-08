using Furny.FileHandlerFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : MediatorControllerBase
    {
        public FileController(IMediator mediator) : base(mediator)
        { }

        [HttpPost]
        public async Task<string> Upload(IFormFile file)
            => await SendAsync(FileHandlerFeatureUploadCommand.Create(file));

        [HttpGet("{id}")]
        public async Task<IActionResult> Download(string id)
            => await SendAsync(FileHandlerFeatureDownloadCommand.Create(id));
    }
}