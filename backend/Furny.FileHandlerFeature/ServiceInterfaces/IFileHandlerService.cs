using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Furny.FileHandlerFeature.ServiceInterfaces
{
    public interface IFileHandlerService
    {
        Task<string> UploadFileAsync(IFormFile file);

        Task<Stream> DownloadFileAsync(string id);
    }
}
