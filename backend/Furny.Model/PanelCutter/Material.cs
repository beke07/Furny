using Furny.Common.Enums;
using Furny.Common.Models;

namespace Furny.Model
{
    public class Material : MongoEntityBase
    {
        public Material() : base()
        { }

        public Material(string id) : base(id)
        { }

        public string Name { get; set; }

        public long Price { get; set; }

        public MaterialType Type { get; set; }

    }
}
