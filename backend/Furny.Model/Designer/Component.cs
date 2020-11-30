using Furny.Common.Models;

namespace Furny.Model
{
    public class Component : MongoEntityBase
    {
        public Component()
        { }

        public Component(string id) : base(id)
        { }

        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public Closings Closings { get; set; }
    }

    public class Closings
    {
        public bool Top { get; set; }

        public bool Bottom { get; set; }

        public bool Left { get; set; }

        public bool Right { get; set; }
    }
}
