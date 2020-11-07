using Furny.Common.Enums;

namespace Furny.Data
{
    public class DesignerOfferTableCommand : TableCommandBase
    {
        public string FurnitureName { get; set; }

        public OfferState State { get; set; }
    }
}
