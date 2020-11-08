using Furny.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureExportCommand : IRequest<FileStreamResult>
    {
        public DesignerFurnitureExportCommand(ExcelType type, string id, string fid)
        {
            Id = id;
            Fid = fid;
            Type = type;
        }

        public string Id { get; set; }

        public string Fid { get; set; }

        public ExcelType Type { get; set; }

        public static DesignerFurnitureExportCommand Create(ExcelType excelType, string id, string fid)
            => new DesignerFurnitureExportCommand(excelType, id, fid);
    }
}
