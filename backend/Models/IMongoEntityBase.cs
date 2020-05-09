using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Models;
using System;

namespace Furny.Models
{
    public interface IMongoEntityBase : IDocument<ObjectId>
    {
        public DateTime CreatedOn { get; }

        public bool IsDeleted { get; set; }
    }

    public class MongoEntityBase : IMongoEntityBase
    {
        public MongoEntityBase()
        {
            Id = ObjectId.GenerateNewId();
            CreatedOn = DateTime.Now;
        }

        public MongoEntityBase(string id)
        {
            Id = ObjectId.TryParse(id, out ObjectId _id) ? _id : ObjectId.GenerateNewId();
            CreatedOn = DateTime.Now;
        }

        public DateTime CreatedOn { get; }

        public bool IsDeleted { get; set; }

        public ObjectId Id { get; set; }

        public int Version { get; set; }
    }
}
