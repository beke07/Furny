using Furny.DesignerFurnitureFeature.Commands;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFurnitureFeature.CommandHandlers
{
    public class DesignerFurnitureComponentCommandHandler :
        IRequestHandler<DesignerFurnitureAddComponentCommand>,
        IRequestHandler<DesignerFurnitureRemoveComponentCommand>
    {
        private readonly IFurnitureService _furnitureService;

        public DesignerFurnitureComponentCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<Unit> Handle(DesignerFurnitureAddComponentCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.AddComponentAsync(request.Component, request.Id, request.Fid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DesignerFurnitureRemoveComponentCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.RemoveComponentAsync(request.Id, request.Fid, request.Cid);

            return Unit.Value;
        }
    }
}
