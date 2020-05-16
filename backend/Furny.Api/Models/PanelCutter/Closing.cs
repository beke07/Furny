namespace Furny.Models
{
    public class Closing : MongoEntityBase
    {
        internal Closing()
        { }

        public Closing(string id) : base(id)
        { }

        public string Name { get; set; }
    }
}
