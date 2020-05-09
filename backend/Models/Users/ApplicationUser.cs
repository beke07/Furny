using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Furny.Models
{
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(Designer), typeof(PanelCutter))]
    public class ApplicationUser : MongoIdentityUser<ObjectId>, IMongoEntityBase
    {
        public ApplicationUser() : base()
        { }

        public ApplicationUser(string userName, string email) : base(userName, email)
        { }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string ImageId { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; }
    }
}
