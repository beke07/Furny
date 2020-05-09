using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class BaseService<T> : IBaseService<T>
        where T : IMongoEntityBase
    {
        protected IMongoDatabase _database { get; set; }

        protected IMongoCollection<T> _collection;

        public BaseService(IConfiguration configuration, string collectionName)
        {
            var client = new MongoClient(configuration.GetConnectionString("FurnyDb"));
            _database = client.GetDatabase("FurnyDb");
            _collection = _database.GetCollection<T>(collectionName);
        }

        public async Task<T> FindByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }
    }
}
