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
    public class OfferFeatureDesignerOfferCommandHandler :
        IRequestHandler<OfferFeatureCreateOfferCommand>,
        IRequestHandler<OfferFeatureDeclineOfferCommand>,
        IRequestHandler<OfferFeatureAcceptOfferCommand>,
        IRequestHandler<OfferFeatureGetDesignerOffersCommand, IList<OfferFeatureOfferDto>>,
        IRequestHandler<OfferFeatureGetDesignerOfferTableCommand, IList<OfferFeatureDesignerOfferTableViewModel>>
    {
        private readonly IOfferService _offerService;

        public OfferFeatureDesignerOfferCommandHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<Unit> Handle(OfferFeatureCreateOfferCommand request, CancellationToken cancellationToken)
        {
            await _offerService.CreateAsnyc(request.Offer, request.Id, request.Fid);

            return Unit.Value;
        }

        public async Task<IList<OfferFeatureOfferDto>> Handle(OfferFeatureGetDesignerOffersCommand request, CancellationToken cancellationToken)
            => await _offerService.GetDesignerOffersAsnyc(request.Id, request.Fid);

        public async Task<IList<OfferFeatureDesignerOfferTableViewModel>> Handle(OfferFeatureGetDesignerOfferTableCommand request, CancellationToken cancellationToken)
            => await _offerService.GetDesignerOfferTableAsnyc(request.Id);

        public async Task<Unit> Handle(OfferFeatureDeclineOfferCommand request, CancellationToken cancellationToken)
        {
            await _offerService.DeclineAsnyc(request.Id);

            return Unit.Value;
        }

        public async Task<Unit> Handle(OfferFeatureAcceptOfferCommand request, CancellationToken cancellationToken)
        {
            await _offerService.AcceptAsnyc(request.Id, request.Fill);

            return Unit.Value;
        }
    }
}
