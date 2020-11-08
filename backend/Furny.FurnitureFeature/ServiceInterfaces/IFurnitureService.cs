using Furny.Common.Enums;
using Furny.Common.ServiceInterfaces;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Furny.FurnitureFeature.ServiceInterfaces
{
    public interface IFurnitureService : ISingleElementService<FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        Task AddModulAsync(string id, string fid, string mid);

        Task RemoveModulAsync(string id, string fid, string mid);

        Task AddComponentAsync(FurnitureComponentDto component, string id, string fid);

        Task CopyComponentAsync(string id, string fid, string cid);

        Task RemoveComponentAsync(string id, string fid, string cid);

        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, string id, string fid);
    }
}
