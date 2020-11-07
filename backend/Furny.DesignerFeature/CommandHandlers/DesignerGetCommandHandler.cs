using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetCommandHandler : IRequestHandler<DesignerGetCommand, DesignerHomeViewModel>
    {
        private readonly IDesignerService _designerService;

        public DesignerGetCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public async Task<DesignerHomeViewModel> Handle(DesignerGetCommand request, CancellationToken cancellationToken)
        {
            return await _designerService.GetAdsAsync(request.Id);
        }
    }
}
