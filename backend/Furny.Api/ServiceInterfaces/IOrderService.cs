using Furny.Data;
using Furny.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IOrderService
    {
        Task CreateAsnyc(Offer offer);

        Task AcceptAsnyc(string id, OrderFillCommand orderDto);

        Task DeclineAsnyc(string id);

        Task DoneAsnyc(string id);

        Task<OrderCommand> GetById(string id);

        Task<IList<PanelCutterOrderTableCommand>> GetPanelOrdersAsnyc(string panelCutterId);

        Task<IList<DesignerOrderTableCommand>> GetDesignerOrdersAsnyc(string designerId);
    }
}