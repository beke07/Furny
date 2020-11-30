using System.ComponentModel;

namespace Furny.Common.Enums
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
        Accepted = 2,
        Declined = 3,
        Done = 4
    }

    public enum OrderState
    {
        Done = 1
    }
}
