using Furny.Common.Enums;
using Furny.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Furny.ExportFeature.ServiceInterfaces
{
    public interface IExportService
    {
        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, IEnumerable<List<Component>> components);
    }
}
