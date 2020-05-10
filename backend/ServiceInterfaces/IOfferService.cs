using Furny.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IOfferService
    {
        Task CreateAsnyc(OfferDto offerDto, string desginerId, string furnitureId);

        Task<IList<OfferDto>> GetDesignerOffersAsnyc(string designerId, string furnitureId);

        Task<List<DesignerOfferTableDto>> GetDesignerOfferTableAsnyc(string designerId, string furnitureId);

        Task<PanelCutterOfferDto> GetPanelCutterOfferAsync(string offerId);

        Task<IList<PanelCutterOfferTabeDto>> GetPanelCutterOfferTableAsync(string panelCutterId);

        Task FillPanelCutterOfferAsync(PanelCutterFillOfferDto offerDto, string oid);
    }
}
