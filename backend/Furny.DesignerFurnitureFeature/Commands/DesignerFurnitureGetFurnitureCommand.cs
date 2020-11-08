using Furny.Common.Commands;
using Furny.DesignerFurnitureFeature.Data;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureGetFurnitureCommand : GetCommand<DesignerFurnitureFurnitureDto>, IGetSingleElementCommandBase
    {
        public DesignerFurnitureGetFurnitureCommand(string id, string fid) : base(id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static DesignerFurnitureGetFurnitureCommand Create(string id, string fid)
            => new DesignerFurnitureGetFurnitureCommand(id, fid);
    }
}
