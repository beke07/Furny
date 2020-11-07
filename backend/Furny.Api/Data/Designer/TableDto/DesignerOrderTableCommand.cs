using Furny.Common.Enums;

namespace Furny.Data
{
    public class DesignerOrderTableCommand : TableCommandBase
    {
        public string Name { get; set; }

        public OrderState? State { get; set; }
    }
}
