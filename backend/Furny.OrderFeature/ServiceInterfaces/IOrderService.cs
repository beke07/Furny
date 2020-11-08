using Furny.Model;
using Furny.OrderFeature.Data;
using Furny.OrderFeature.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.OrderFeature.ServiceInterfaces
{
    public interface IOrderService
    {
        Task CreateAsnyc(Offer offer);

        Task AcceptAsnyc(string id, OrderFeatureOrderFillDto orderDto);

        Task DeclineAsnyc(string id);

        Task DoneAsnyc(string id);

        Task<OrderFeatureOrderViewModel> GetById(string id);

        Task<IList<OrderFeaturePanelCutterTableViewModel>> GetPanelCutterOrdersAsnyc(string panelCutterId);

        Task<IList<OrderFeatureDesignerTableViewModel>> GetDesignerOrdersAsnyc(string designerId);
    }
}