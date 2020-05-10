using MongoDB.Bson;

namespace Furny.Models
{
    public class Furniture : MongoEntityBase
    {
        internal Furniture()
        { }

        public Furniture(string id) : base(id)
        { }

        public string Name { get; set; }

        public SingleElement<Modul> Moduls { get; set; } = new SingleElement<Modul>();

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
