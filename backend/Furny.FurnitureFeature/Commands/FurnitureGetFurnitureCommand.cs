using Furny.Common.Commands;
using Furny.FurnitureFeature.Data;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureGetFurnitureCommand : GetCommand<FurnitureFurnitureDto>, IGetSingleElementCommandBase
    {
        public FurnitureGetFurnitureCommand(string id, string fid) : base(id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static FurnitureGetFurnitureCommand Create(string id, string fid)
            => new FurnitureGetFurnitureCommand(id, fid);
    }
}
