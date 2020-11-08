using Furny.Common.Commands;
using Furny.Common.Enums;

namespace Furny.OrderFeature.ViewModels
{
    public class OrderFeatureDesignerTableViewModel : TableBaseViewModel
    {
        public string Name { get; set; }

        public OrderState? State { get; set; }
    }
}
