using Furny.Common.Enums;

namespace Furny.Data
{
    public class PanelCutterOfferTabeCommand : TableCommandBase
    {
        public string DesignerName { get; set; }

        public OfferState? State { get; set; }
    }
}
