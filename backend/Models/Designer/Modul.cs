using MongoDB.Bson;

namespace Furny.Models
{
    public class Modul : MongoEntityBase
    {
        internal Modul()
        { }

        public Modul(string id) : base(id)
        { }

        public string Name { get; set; }

        public SingleElement<Component> Components { get; set; } = new SingleElement<Component>();

        internal void CopyComponent(string id)
        {
            var component = Components.GetById(id);
            var newComponent = new Component()
            {
                Id = ObjectId.GenerateNewId(),
                Width = component.Width,
                Height = component.Height,
                Name = component.Name,
                Closings = component.Closings,
            };
            Components.Add(newComponent);
        }
    }
}
