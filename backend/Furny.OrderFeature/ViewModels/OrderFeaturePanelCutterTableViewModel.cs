using Furny.Common.Commands;
using Furny.Common.Enums;

namespace Furny.OrderFeature.ViewModels
{
    public class OrderFeaturePanelCutterTableViewModel : TableBaseViewModel
    {
        public string OfferId { get; set; }

        public string DesignerName { get; set; }

        public OrderState? State { get; set; }
    }
}
