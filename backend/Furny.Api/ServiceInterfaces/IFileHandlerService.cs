using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System.IO;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IFileHandlerService
    {
        Task<string> UploadFileAsync(IFormFile file);

        Task<Stream> DownloadFileAsync(string id);
    }
}
