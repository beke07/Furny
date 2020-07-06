using Furny.Data;
using Furny.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IOrderService
    {
        Task CreateAsnyc(Offer offer);

        Task AcceptAsnyc(string id, OrderFillDto orderDto);

        Task DeclineAsnyc(string id);

        Task DoneAsnyc(string id);

        Task<OrderDto> GetById(string id);

        Task<IList<PanelCutterOrderTableDto>> GetPanelOrdersAsnyc(string panelCutterId);

        Task<IList<DesignerOrderTableDto>> GetDesignerOrdersAsnyc(string designerId);
    }
}