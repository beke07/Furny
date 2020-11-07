using Furny.Common.Enums;
using Furny.Data;
using Furny.Data.Designer.TableDto;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IFurnitureService : ISingleElementService<FurnitureCommand, FurnitureTableCommand>
    {
        Task AddModulAsync(string id, string fid, string mid);

        Task RemoveModulAsync(string id, string fid, string mid);

        Task AddComponentAsync(ComponentCommand component, string id, string fid);

        Task CopyComponentAsync(string id, string fid, string cid);

        Task RemoveComponentAsync(string id, string fid, string cid);

        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, string id, string fid);
    }
}
