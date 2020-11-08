using Furny.DesignerFurnitureFeature.Commands;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFurnitureFeature.CommandHandlers
{
    public class DesignerFurnitureModulCommandHandler :
        IRequestHandler<DesignerFurnitureAddModulCommand>,
        IRequestHandler<DesignerFurnitureRemoveModulCommand>
    {
        private readonly IFurnitureService _furnitureService;

        public DesignerFurnitureModulCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<Unit> Handle(DesignerFurnitureAddModulCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.AddModulAsync(request.Id, request.Fid, request.Mid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DesignerFurnitureRemoveModulCommand request, CancellationToken cancellationToken)
        {
            await _furnitureService.RemoveModulAsync(request.Id, request.Fid, request.Mid);

            return Unit.Value;
        }
    }
}
