using Furny.Common.Commands;
using Furny.FurnitureFeature.Data;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureUpdateFurnitureCommand : UpdateCommand<FurnitureFurnitureDto>, IUpdateSingleElementCommandBase<FurnitureFurnitureDto>
    {
        public FurnitureUpdateFurnitureCommand(JsonPatchDocument<FurnitureFurnitureDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static FurnitureUpdateFurnitureCommand Create(JsonPatchDocument<FurnitureFurnitureDto> patch, string id, string fid)
            => new FurnitureUpdateFurnitureCommand(patch, id, fid);
    }
}
