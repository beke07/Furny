using Furny.ExportFeature.ServiceInterfaces;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.ExportFeature.Commands
{
    public class ExportCommandHandler : IRequestHandler<ExportCommand, Tuple<MemoryStream, string>>
    {
        private readonly IExportService _exportService;

        public ExportCommandHandler(IExportService exportService)
        {
            _exportService = exportService;
        }

        public async Task<Tuple<MemoryStream, string>> Handle(ExportCommand request, CancellationToken cancellationToken)
        {
            return await _exportService.ExportAsync(request.Type, request.Components);
        }
    }
}
