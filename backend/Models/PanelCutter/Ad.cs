using MongoDB.Bson.Serialization.Attributes;

namespace Furny.Models
{
    public class Ad : MongoEntityBase
    {
        internal Ad()
        { }

        public Ad(string id) : base(id)
        { }

        public string Title { get; set; }

        public string Text { get; set; }

        public string ImageId { get; set; }
    }
}
