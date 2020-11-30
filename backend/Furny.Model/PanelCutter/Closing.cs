using Furny.Common.Models;

namespace Furny.Model
{
    public class Closing : MongoEntityBase
    {
        internal Closing()
        { }

        public Closing(string id) : base(id)
        { }

        public string Name { get; set; }

        public long Price { get; set; }
    }
}
