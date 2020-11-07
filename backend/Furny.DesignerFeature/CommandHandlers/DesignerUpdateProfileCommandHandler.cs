using Furny.DesignerFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerUpdateProfileCommandHandler : IRequestHandler<DesignerUpdateProfileCommand>
    {
        private readonly IDesignerService _designerService;

        public DesignerUpdateProfileCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public async Task<Unit> Handle(DesignerUpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await _designerService.UpdateProfileAsync(request.Patch, request.Id);

            return Unit.Value;
        }
    }
}
