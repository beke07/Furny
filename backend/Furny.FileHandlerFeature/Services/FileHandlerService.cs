using Furny.FileHandlerFeature.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Threading.Tasks;

namespace Furny.FileHandlerFeature.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly IMongoDatabase _database;

        public FileHandlerService(IConfiguration configuration)
        {
            var dbName = configuration.GetSection("DbName").Value;
            var client = new MongoClient(configuration.GetConnectionString(dbName));
            _database = client.GetDatabase(dbName);
        }

        private IGridFSBucket CreateBucket(string name)
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

        private async Task<ObjectId> UploadFileAsync(string fileName, Stream file)
        {
            var bucket = CreateBucket("images");
            return await bucket.UploadFromStreamAsync(fileName, file);
        }

        public async Task<Stream> DownloadFileAsync(string id)
        {
            var bucket = CreateBucket("images");
            var file = new MemoryStream();
            await bucket.DownloadToStreamAsync(new ObjectId(id), file);
            file.Position = 0;
            return file;
        }
    }
}
