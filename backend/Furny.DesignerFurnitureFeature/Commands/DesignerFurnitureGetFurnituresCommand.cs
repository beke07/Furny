using Furny.Common.Commands;
using Furny.DesignerFurnitureFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureGetFurnituresCommand : GetCommand<IList<DesignerFurnitureFurnitureTableViewModel>>, IGetSingleElementCommandBase
    {
        public DesignerFurnitureGetFurnituresCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static DesignerFurnitureGetFurnituresCommand Create(string id)
            => new DesignerFurnitureGetFurnituresCommand(id);
    }
}
