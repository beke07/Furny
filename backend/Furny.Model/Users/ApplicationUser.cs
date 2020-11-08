using AspNetCore.Identity.MongoDbCore.Models;
using Furny.Common.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Furny.Model
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

        public UserAddress UserAddress { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; }

        public IList<Notification> Notifications { get; set; } = new List<Notification>();

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public void DoneNotification(string id)
        {
            Notifications.SingleOrDefault(e => e.Id == ObjectId.Parse(id)).IsDone = true;
        }
    }
}
