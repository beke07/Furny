using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Common
{
    public class Enums
    {
        public enum MaterialType
        {
            Table = 1,
            M2 = 2
        }

        public enum ExcelType
        {
            [Description("szabaszati-megrendelo-arajanlat")]
            ErFa = 1
        }

        public enum OfferState
        {
            Created = 1,
            Done = 2
        }

        public enum OrderState
        {
            Created = 1,
            Done = 2
        }
    }
}
