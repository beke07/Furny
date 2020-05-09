using MongoDB.Bson.Serialization.Attributes;

namespace Furny.Models
{
    public class Ad : MongoEntityBase
    {
        internal Ad()
        { }

        public string Text { get; set; }

        public string ImageId { get; set; }
    }
}
