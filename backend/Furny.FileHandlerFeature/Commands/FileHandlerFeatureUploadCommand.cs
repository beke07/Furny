using MediatR;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

namespace Furny.FileHandlerFeature.Commands
{
    public class FileHandlerFeatureUploadCommand : IRequest<string>
    {
        public FileHandlerFeatureUploadCommand(IFormFile file)
        {
            File = file;
        }

        public IFormFile File { get; set; }

        public static FileHandlerFeatureUploadCommand Create(IFormFile file)
            => new FileHandlerFeatureUploadCommand(file);
    }
}
