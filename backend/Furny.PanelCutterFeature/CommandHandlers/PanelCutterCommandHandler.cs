using Furny.Common.Enums;
using Furny.Common.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.OfferFeature.Commands;
using Furny.OrderFeature.Commands;
using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.ServiceInterfaces;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.PanelCutterFeature.CommandHandlers
{
    public class PanelCutterCommandHandler :
        IRequestHandler<GetPanelCutterCommand, PanelCutter>,
        IRequestHandler<GetPanelCutterAdsCommand, IList<AdViewModel>>,
        IRequestHandler<PanelCutterUpdateProfileCommand>,
        IRequestHandler<PanelCutterGetProfileCommand, PanelCutterProfileViewModel>,
        IRequestHandler<PanelCutterGetCommand, PanelCutterHomeViewModel>
    {
        private readonly IMediator _mediator;
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterCommandHandler(
            IMediator mediator,
            IPanelCutterService panelCutterService)
        {
            _mediator = mediator;
            _panelCutterService = panelCutterService;
        }

        public async Task<PanelCutter> Handle(GetPanelCutterCommand request, CancellationToken cancellationToken)
            => await _panelCutterService.FindByIdAsync(request.Id);

        public async Task<IList<AdViewModel>> Handle(GetPanelCutterAdsCommand request, CancellationToken cancellationToken)
            => await _panelCutterService.GetAdsByCountry(request.Country);

        public async Task<PanelCutterProfileViewModel> Handle(PanelCutterGetProfileCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                request.Id = await _panelCutterService.GetIdByEmailAsync(request.Email);

            return await _panelCutterService.GetProfileAsync(request.Id);
        }

        public async Task<Unit> Handle(PanelCutterUpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await _panelCutterService.UpdateProfileAsync(request.Patch, request.Id);

            return Unit.Value;
        }

        public async Task<PanelCutterHomeViewModel> Handle(PanelCutterGetCommand request, CancellationToken cancellationToken)
        {
            return new PanelCutterHomeViewModel()
            {
                Offers = (await _mediator.Send(new OfferFeatureGetPanelCutterOfferTableCommand(request.Id))).Where(e => e.State == OfferState.Created).Count(),
                Orders = (await _mediator.Send(new OrderFeatureGetPanelCutterOrdersCommand(request.Id))).Where(e => !e.State.HasValue).Count(),
            };
        }
    }
}
