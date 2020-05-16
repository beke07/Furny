using static Furny.Common.Enums;

namespace Furny.Data
{
    public class PanelCutterOrderTableDto : TableDtoBase
    {
        public string DesignerName { get; set; }

        public OrderState? State { get; set; }
    }
}
