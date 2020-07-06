using Furny.Data;
using Furny.Data.Designer.TableDto;
using System;
using System.IO;
using System.Threading.Tasks;
using static Furny.Common.Enums;

namespace Furny.ServiceInterfaces
{
    public interface IFurnitureService : ISingleElementService<FurnitureDto, FurnitureTableDto>
    {
        Task AddModulAsync(string id, string fid, string mid);

        Task RemoveModulAsync(string id, string fid, string mid);

        Task AddComponentAsync(ComponentDto component, string id, string fid);

        Task CopyComponentAsync(string id, string fid, string cid);

        Task RemoveComponentAsync(string id, string fid, string cid);

        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, string id, string fid);
    }
}
