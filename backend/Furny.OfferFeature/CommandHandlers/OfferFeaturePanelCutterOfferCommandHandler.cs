using Furny.OfferFeature.Commands;
using Furny.OfferFeature.Data;
using Furny.OfferFeature.ServiceInterfaces;
using Furny.OfferFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.OfferFeature.CommandHandlers
{
    public class OfferFeaturePanelCutterOfferCommandHandler :
        IRequestHandler<OfferFeatureGetPanelCutterOfferCommand, OfferFeaturePanelCutterOfferDto>,
        IRequestHandler<OfferFeatureGetPanelCutterOfferTableCommand, IList<OfferFeaturePanelCutterOfferTableViewModel>>,
        IRequestHandler<OfferFeatureGetPanelCutterFillOfferCommand>
    {
        private readonly IOfferService _offerService;

        public OfferFeaturePanelCutterOfferCommandHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<OfferFeaturePanelCutterOfferDto> Handle(OfferFeatureGetPanelCutterOfferCommand request, CancellationToken cancellationToken)
            => await _offerService.GetPanelCutterOfferAsync(request.Id);

        public async Task<IList<OfferFeaturePanelCutterOfferTableViewModel>> Handle(OfferFeatureGetPanelCutterOfferTableCommand request, CancellationToken cancellationToken)
            => await _offerService.GetPanelCutterOfferTableAsync(request.PanelCutterId);

        public async Task<Unit> Handle(OfferFeatureGetPanelCutterFillOfferCommand request, CancellationToken cancellationToken)
        {
            await _offerService.FillPanelCutterOfferAsync(request.Fill, request.Id);

            return Unit.Value;
        }
    }
}
