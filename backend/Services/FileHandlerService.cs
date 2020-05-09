using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class FileHandlerService : BaseService, IFileHandlerService
    {
        public FileHandlerService(IConfiguration configuration) : base(configuration)
        { }

        public IGridFSBucket CreateBucket(string name)
        {
            return new GridFSBucket(_database, new GridFSBucketOptions
            {
                BucketName = name,
                ChunkSizeBytes = 10048576,
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Secondary
            });
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return null;
            }

            using (var fileStream = file.OpenReadStream())
            {
                return (await UploadFileAsync(file.FileName, fileStream)).ToString();
            }
        }

        public async Task<ObjectId> UploadFileAsync(string fileName, Stream file)
        {
            var bucket = CreateBucket("images");
            return await bucket.UploadFromStreamAsync(fileName, file);
        }

        public async Task<byte[]> DownloadFileAsync(ObjectId id)
        {
            var bucket = CreateBucket("images");
            return await bucket.DownloadAsBytesAsync(id);
        }
    }
}
