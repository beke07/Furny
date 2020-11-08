using Furny.Common.Commands;
using Furny.DesignerFurnitureFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureUpdateFurnitureCommand : UpdateCommand<DesignerFurnitureFurnitureDto>, IUpdateSingleElementCommandBase<DesignerFurnitureFurnitureDto>
    {
        public DesignerFurnitureUpdateFurnitureCommand(JsonPatchDocument<DesignerFurnitureFurnitureDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static DesignerFurnitureUpdateFurnitureCommand Create(JsonPatchDocument<DesignerFurnitureFurnitureDto> patch, string id, string fid)
            => new DesignerFurnitureUpdateFurnitureCommand(patch, id, fid);
    }
}
