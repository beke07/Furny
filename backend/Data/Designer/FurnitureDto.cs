using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data.Designer
{
    public class FurnitureDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public string DesignerId { get; set; }

        public IList<string> Moduls { get; set; }

        public IList<ComponentDto> Components { get; set; }
    }
}
