using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Furny.Common.Enums;

namespace Furny.Data
{
    public class DesignerOfferTableDto : TableDtoBase
    {
        public string FurnitureName { get; set; }

        public OfferState State { get; set; }
    }
}
