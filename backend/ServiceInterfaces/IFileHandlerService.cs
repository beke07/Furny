using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System.IO;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IFileHandlerService
    {
        Task<ObjectId> UploadFileAsync(string fileName, Stream file);

        Task<string> UploadFileAsync(IFormFile file);

        Task<byte[]> DownloadFileAsync(ObjectId id);
    }
}
