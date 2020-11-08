using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furny.FileHandlerFeature.Commands
{
    public class FileHandlerFeatureDownloadCommand : IRequest<FileStreamResult>
    {
        public FileHandlerFeatureDownloadCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static FileHandlerFeatureDownloadCommand Create(string id)
            => new FileHandlerFeatureDownloadCommand(id);
    }
}
