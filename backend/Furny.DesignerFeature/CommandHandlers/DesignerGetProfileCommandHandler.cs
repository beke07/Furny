using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetProfileCommandHandler : IRequestHandler<DesignerGetProfileCommand, DesignerProfileViewModel>
    {
        private readonly IDesignerService _designerService;

        public DesignerGetProfileCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public async Task<DesignerProfileViewModel> Handle(DesignerGetProfileCommand request, CancellationToken cancellationToken)
        {
            return await _designerService.GetProfileAsync(request.Id);
        }
    }
}
