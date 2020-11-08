using Furny.Common.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.ServiceInterfaces;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.PanelCutterFeature.CommandHandlers
{
    public class PanelCutterCommandHandler :
        IRequestHandler<GetPanelCutterCommand, PanelCutter>,
        IRequestHandler<GetPanelCutterAdsCommand, IList<AdViewModel>>,
        IRequestHandler<PanelCutterUpdateProfileCommand>,
        IRequestHandler<PanelCutterGetProfileCommand, PanelCutterProfileViewModel>
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterCommandHandler(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public async Task<PanelCutter> Handle(GetPanelCutterCommand request, CancellationToken cancellationToken)
            => await _panelCutterService.FindByIdAsync(request.Id);

        public async Task<IList<AdViewModel>> Handle(GetPanelCutterAdsCommand request, CancellationToken cancellationToken)
            => await _panelCutterService.GetAdsByCountry(request.Country);

        public async Task<PanelCutterProfileViewModel> Handle(PanelCutterGetProfileCommand request, CancellationToken cancellationToken)
            => await _panelCutterService.GetProfileAsync(request.Id);

        public async Task<Unit> Handle(PanelCutterUpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await _panelCutterService.UpdateProfileAsync(request.Patch, request.Id);

            return Unit.Value;
        }


    }
}
