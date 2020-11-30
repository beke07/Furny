using Furny.Model;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ViewModels;
using Furny.OrderFeature.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.OfferFeature.ServiceInterfaces
{
    public interface IOfferService
    {
        Task CreateAsnyc(OfferFeatureOfferDto offerDto, string designerId, string furnitureId);

        Task AcceptAsnyc(string id, OrderFeatureOrderFillDto orderDto);

        Task DeclineAsnyc(string id);

        Task<IList<OfferFeatureOfferDto>> GetDesignerOffersAsnyc(string designerId, string furnitureId);

        Task<List<OfferFeatureDesignerOfferTableViewModel>> GetDesignerOfferTableAsnyc(string designerId);

        Task<OfferFeaturePanelCutterOfferDto> GetPanelCutterOfferAsync(string offerId);

        Task<IList<OfferFeaturePanelCutterOfferTableViewModel>> GetPanelCutterOfferTableAsync(string panelCutterId);

        Task FillPanelCutterOfferAsync(OfferFeaturePanelCutterFillOfferDto offerDto, string oid);
    }
}
