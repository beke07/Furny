using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data
{
    public class ComponentTableDto : TableDtoBase
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
