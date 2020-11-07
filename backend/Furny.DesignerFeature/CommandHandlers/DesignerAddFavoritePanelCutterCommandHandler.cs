using Furny.DesignerFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerAddFavoritePanelCutterCommandHandler : IRequestHandler<DesignerAddFavoritePanelCutterCommand>
    {
        private readonly IDesignerService _designerService;

        public DesignerAddFavoritePanelCutterCommandHandler(IDesignerService designerService)
        {
            _designerService = designerService;
        }
        public async Task<Unit> Handle(DesignerAddFavoritePanelCutterCommand request, CancellationToken cancellationToken)
        {
            await _designerService.AddFavoritePanelCutterAsync(request.Id, request.Pid);
            
            return Unit.Value;
        }
    }
}
