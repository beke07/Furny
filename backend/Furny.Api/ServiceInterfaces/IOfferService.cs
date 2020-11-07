using Furny.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IOfferService
    {
        Task CreateAsnyc(OfferCommand offerDto, string desginerId, string furnitureId);

        Task<IList<OfferCommand>> GetDesignerOffersAsnyc(string designerId, string furnitureId);

        Task<List<DesignerOfferTableCommand>> GetDesignerOfferTableAsnyc(string designerId, string furnitureId);

        Task<PanelCutterOfferCommand> GetPanelCutterOfferAsync(string offerId);

        Task<IList<PanelCutterOfferTabeCommand>> GetPanelCutterOfferTableAsync(string panelCutterId);

        Task FillPanelCutterOfferAsync(PanelCutterFillOfferCommand offerDto, string oid);
    }
}
