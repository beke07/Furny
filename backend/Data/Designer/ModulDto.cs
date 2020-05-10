using System.Collections.Generic;

namespace Furny.Data
{
    public class ModulDto
    {
        public string _id { get; set; }

        public string Name  { get; set; }

        public IList<ComponentDto> Components { get; set; }
    }
}
