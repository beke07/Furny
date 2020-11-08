using Furny.Common.Enums;
using Furny.Common.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Furny.DesignerFurnitureFeature.ServiceInterfaces
{
    public interface IFurnitureService : ISingleElementService<DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>
    {
        Task AddModulAsync(string id, string fid, string mid);

        Task RemoveModulAsync(string id, string fid, string mid);

        Task AddComponentAsync(DesignerFurnitureComponentDto component, string id, string fid);

        Task CopyComponentAsync(string id, string fid, string cid);

        Task RemoveComponentAsync(string id, string fid, string cid);

        Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, string id, string fid);
    }
}
