using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.ViewModels;
using Furny.Model;
using Furny.Model.Common.Commands;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetCommandHandler :
        IRequestHandler<GetDesignerCommand, Designer>,
        IRequestHandler<DesignerGetCommand, DesignerHomeViewModel>,
        IRequestHandler<DesignerGetFavoritePanelCutterCommand, IList<DesignerFavoriteViewModel>>
    {
        private readonly IDesignerService _designerService;

        public DesignerGetCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public async Task<DesignerHomeViewModel> Handle(DesignerGetCommand request, CancellationToken cancellationToken)
            => await _designerService.GetAdsAsync(request.Id);


        public async Task<Designer> Handle(GetDesignerCommand request, CancellationToken cancellationToken)
            => await _designerService.FindByIdAsync(request.Id);


        public async Task<IList<DesignerFavoriteViewModel>> Handle(DesignerGetFavoritePanelCutterCommand request, CancellationToken cancellationToken)
            => await _designerService.GetFavoritesAsnyc(request.Id);
    }
}
