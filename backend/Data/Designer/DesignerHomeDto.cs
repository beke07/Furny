using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data.Designer
{
    public class DesignerHomeDto
    {
        public IList<DesignerAdDto> Ads { get; set; }
    }
}
