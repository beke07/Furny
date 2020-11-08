using Furny.FurnitureFeature.Commands;
using Furny.FurnitureFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.FurnitureFeature.CommandHandlers
{
    public class FurnitureModulCommandHandler :
        IRequestHandler<FurnitureAddModulCommand>,
        IRequestHandler<FurnitureRemoveModulCommand>
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureModulCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<Unit> Handle(FurnitureAddModulCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.AddModulAsync(request.Id, request.Fid, request.Mid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(FurnitureRemoveModulCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.RemoveModulAsync(request.Id, request.Fid, request.Mid);

            return Unit.Value;
        }
    }
}
