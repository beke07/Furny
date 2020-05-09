﻿using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileHandlerService _fileHandlerService;

        public FileController(IFileHandlerService fileHandlerService)
        {
            _fileHandlerService = fileHandlerService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            return Ok(new { imageId = await _fileHandlerService.UploadFileAsync(file) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Download(string id)
        {
            var image = await _fileHandlerService.DownloadFileAsync(id);
            return new FileStreamResult(image, MediaTypeNames.Image.Jpeg);
        }
    }
}