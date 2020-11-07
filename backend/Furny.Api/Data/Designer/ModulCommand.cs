using System.Collections.Generic;

namespace Furny.Data
{
    public class ModulCommand
    {
        public string _id { get; set; }

        public string Name  { get; set; }

        public IList<ComponentCommand> Components { get; set; }
    }
}
