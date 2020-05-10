using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class ModulDto
    {
        public string _id { get; set; }

        public string Name  { get; set; }

        public IList<ComponentDto> Components { get; set; }
    }
}
