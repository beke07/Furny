using Furny.FurnitureFeature.Commands;
using Furny.FurnitureFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.FurnitureFeature.CommandHandlers
{
    public class FurnitureComponentCommandHandler :
        IRequestHandler<FurnitureAddComponentCommand>,
        IRequestHandler<FurnitureRemoveComponentCommand>
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureComponentCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<Unit> Handle(FurnitureAddComponentCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.AddComponentAsync(request.Component, request.Id, request.Fid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(FurnitureRemoveComponentCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.RemoveComponentAsync(request.Id, request.Fid, request.Cid);

            return Unit.Value;
        }
    }
}
