using System.Collections.Generic;

namespace Furny.ModulFeature.Data
{
    public class ModulModulDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public IList<ModulComponentDto> Components { get; set; }
    }
}
