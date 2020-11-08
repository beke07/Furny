using Furny.OfferFeature.Data;
using Furny.OfferFeature.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.OfferFeature.ServiceInterfaces
{
    public interface IOfferService
    {
        Task CreateAsnyc(OfferFeatureOfferDto offerDto, string desginerId, string furnitureId);

        Task<IList<OfferFeatureOfferDto>> GetDesignerOffersAsnyc(string designerId, string furnitureId);

        Task<List<OfferFeatureDesignerOfferTableViewModel>> GetDesignerOfferTableAsnyc(string designerId, string furnitureId);

        Task<OfferFeaturePanelCutterOfferDto> GetPanelCutterOfferAsync(string offerId);

        Task<IList<OfferFeaturePanelCutterOfferTableViewModel>> GetPanelCutterOfferTableAsync(string panelCutterId);

        Task FillPanelCutterOfferAsync(OfferFeaturePanelCutterFillOfferDto offerDto, string oid);
    }
}
