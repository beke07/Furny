using Furny.Common.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using Furny.PanelCutterFeature.ServiceInterfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.PanelCutterFeature.CommandHandlers
{
    public class PanelCutterGetCommandHandler
        : IRequestHandler<GetPanelCutterCommand, PanelCutter>,
          IRequestHandler<GetPanelCutterAdsCommand, IList<AdViewModel>>
    {
        private readonly IPanelCutterService _panelCutterService;

        public PanelCutterGetCommandHandler(IPanelCutterService panelCutterService)
        {
            _panelCutterService = panelCutterService;
        }

        public async Task<PanelCutter> Handle(GetPanelCutterCommand request, CancellationToken cancellationToken)
        {
            return await _panelCutterService.FindByIdAsync(request.Id);
        }

        public async Task<IList<AdViewModel>> Handle(GetPanelCutterAdsCommand request, CancellationToken cancellationToken)
        {
            return await _panelCutterService.GetAdsByCountry(request.Country);
        }
    }
}
