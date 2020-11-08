using Furny.FileHandlerFeature.Commands;
using Furny.FileHandlerFeature.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.FileHandlerFeature.CommandHandlers
{
    public class FileHandlerFeatureCommandHandler :
        IRequestHandler<FileHandlerFeatureDownloadCommand, FileStreamResult>,
        IRequestHandler<FileHandlerFeatureUploadCommand, string>
    {
        private readonly IFileHandlerService _fileHandlerService;

        public FileHandlerFeatureCommandHandler(IFileHandlerService fileHandlerService)
        {
            _fileHandlerService = fileHandlerService;
        }

        public async Task<FileStreamResult> Handle(FileHandlerFeatureDownloadCommand request, CancellationToken cancellationToken)
        {
            var image = await _fileHandlerService.DownloadFileAsync(request.Id);
            return new FileStreamResult(image, MediaTypeNames.Image.Jpeg);
        }

        public async Task<string> Handle(FileHandlerFeatureUploadCommand request, CancellationToken cancellationToken)
            => await _fileHandlerService.UploadFileAsync(request.File);
    }
}
