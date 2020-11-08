using Furny.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureExportCommand : IRequest<FileStreamResult>
    {
        public FurnitureExportCommand(ExcelType type, string id, string fid)
        {
            Id = id;
            Fid = fid;
            Type = type;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public ExcelType Type { get; set; }

        public static FurnitureExportCommand Create(ExcelType excelType, string id, string fid)
            => new FurnitureExportCommand(excelType, id, fid);
    }
}
