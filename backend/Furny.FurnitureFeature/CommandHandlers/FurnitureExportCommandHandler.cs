using Furny.FurnitureFeature.Commands;
using Furny.FurnitureFeature.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.FurnitureFeature.CommandHandlers
{
    public class FurnitureExportCommandHandler : IRequestHandler<FurnitureExportCommand, FileStreamResult>
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureExportCommandHandler(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        public async Task<FileStreamResult> Handle(FurnitureExportCommand request, CancellationToken cancellationToken)
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
