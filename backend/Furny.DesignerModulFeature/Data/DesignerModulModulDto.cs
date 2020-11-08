using System.Collections.Generic;

namespace Furny.DesignerModulFeature.Data
{
    public class DesignerModulModulDto
    {
        public string _id { get; set; }

        public string Name { get; set; }

        public IList<DesignerModulComponentDto> Components { get; set; }
    }
}
