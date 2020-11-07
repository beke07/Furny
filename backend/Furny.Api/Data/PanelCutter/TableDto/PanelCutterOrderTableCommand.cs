using Furny.Common.Enums;

namespace Furny.Data
{
    public class PanelCutterOrderTableCommand : TableCommandBase
    {
        public string DesignerName { get; set; }

        public OrderState? State { get; set; }
    }
}
