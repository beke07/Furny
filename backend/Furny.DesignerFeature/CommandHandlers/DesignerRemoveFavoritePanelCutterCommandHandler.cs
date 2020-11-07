using Furny.DesignerFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerRemoveFavoritePanelCutterCommandHandler : IRequestHandler<DesignerRemoveFavoritePanelCutterCommand>
    {
        private readonly IDesignerService _designerService;

        public DesignerRemoveFavoritePanelCutterCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }

        public async Task<Unit> Handle(DesignerRemoveFavoritePanelCutterCommand request, CancellationToken cancellationToken)
        {
            await _designerService.RemoveFavoritePanelCutterAsync(request.Id, request.Pid);

            return Unit.Value;
        }
    }
}
