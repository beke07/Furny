using Furny.ModulFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.ModulFeature.Commands
{
    public class ModulComponentCommandHandler :
        IRequestHandler<ModulAddComponentCommand>,
        IRequestHandler<ModulRemoveComponentCommand>,
        IRequestHandler<ModulCopyComponentCommand>
    {
        private readonly IModulService _modulService;

        public ModulComponentCommandHandler(IModulService modulService)
        {
            _modulService = modulService;
        }

        public async Task<Unit> Handle(ModulAddComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.AddComponentAsync(request.Component, request.Id, request.Mid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(ModulRemoveComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.RemoveComponentAsync(request.Id, request.Mid, request.Cid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(ModulCopyComponentCommand request, CancellationToken cancellationToken)
        {
            await _modulService.CopyComponentAsync(request.Id, request.Mid, request.Cid);

            return Unit.Value;
        }
    }
}
