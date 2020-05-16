using static Furny.Common.Enums;

namespace Furny.Data
{
    public class DesignerOrderTableDto : TableDtoBase
    {
        public string Name { get; set; }

        public OrderState? State { get; set; }
    }
}
