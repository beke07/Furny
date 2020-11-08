using Furny.DesignerFurnitureFeature.Commands;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.DesignerFurnitureFeature.CommandHandlers
{
    public class DesignerFurnitureExportCommandHandler : IRequestHandler<DesignerFurnitureExportCommand, FileStreamResult>
    {
        private readonly IFurnitureService _furnitureService;

        public DesignerFurnitureExportCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<FileStreamResult> Handle(DesignerFurnitureExportCommand request, CancellationToken cancellationToken)
        {
            var result = await _furnitureService.ExportAsync(request.Type, request.Id, request.Fid);

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            return new FileStreamResult(result.Item1, contentType)
            {
                FileDownloadName = Path.GetFileName(result.Item2)
            };
        }
    }
}
