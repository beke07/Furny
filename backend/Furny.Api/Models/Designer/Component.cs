namespace Furny.Models
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
        public ComponentClosing Top { get; set; }

        public ComponentClosing Bottom { get; set; }

        public ComponentClosing Left { get; set; }

        public ComponentClosing Right { get; set; }
    }

    public class ComponentClosing
    {
        public bool IsClosed { get; set; }
    }
}
