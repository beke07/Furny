using Furny.Common.Enums;
using Furny.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;

namespace Furny.ExportFeature.Commands
{
    public class ExportCommand : IRequest<Tuple<MemoryStream, string>>
    {
        public ExportCommand(ExcelType type, IEnumerable<List<Component>> components)
        {
            Type = type;
            Components = components;
        }

        public ExcelType Type { get; set; }

        public IEnumerable<List<Component>> Components { get; set; }

        public static ExportCommand Create(ExcelType excelType, IEnumerable<List<Component>> resultComponents)
            => new ExportCommand(excelType, resultComponents);
    }
}
