using System.Collections.Generic;

namespace Furny.Data
{
    public class FurnitureCommand
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public string DesignerId { get; set; }

        public IList<string> Moduls { get; set; }

        public IList<ComponentCommand> Components { get; set; }
    }
}
