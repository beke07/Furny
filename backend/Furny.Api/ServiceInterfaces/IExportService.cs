using Furny.Common.Enums;
using Furny.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IExportService
    {
        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, IEnumerable<List<Component>> components);
    }
}
