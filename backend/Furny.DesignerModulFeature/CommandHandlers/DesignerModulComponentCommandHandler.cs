using Furny.DesignerModulFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerModulFeature.Commands
{
    public class DesignerModulComponentCommandHandler :
        IRequestHandler<DesignerModulAddComponentCommand>,
        IRequestHandler<DesignerModulRemoveComponentCommand>,
        IRequestHandler<DesignerModulCopyComponentCommand>
    {
        private readonly IModulService _modulService;

        public DesignerModulComponentCommandHandler(IModulService modulService)
        {
            _modulService = modulService;
        }

        public async Task<Unit> Handle(DesignerModulAddComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.AddComponentAsync(request.Component, request.Id, request.Mid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DesignerModulRemoveComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.RemoveComponentAsync(request.Id, request.Mid, request.Cid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DesignerModulCopyComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.CopyComponentAsync(request.Id, request.Mid, request.Cid);

            return Unit.Value;
        }
    }
}
