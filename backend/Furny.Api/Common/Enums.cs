using System.ComponentModel;

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
            Accepted = 1,
            Declined = 2,
            Done = 3
        }
    }
}
