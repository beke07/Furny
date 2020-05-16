using static Furny.Common.Enums;

namespace Furny.Data
{
    public class PanelCutterOfferTabeDto : TableDtoBase
    {
        public string DesignerName { get; set; }

        public OfferState? State { get; set; }
    }
}
