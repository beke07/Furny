using Furny.Common.Commands;
using Furny.FurnitureFeature.ViewModels;
using System.Collections.Generic;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureGetFurnituresCommand : GetCommand<IList<FurnitureFurnitureTableViewModel>>, IGetSingleElementCommandBase
    {
        public FurnitureGetFurnituresCommand(string id) : base(id)
        { }

        public string ElementId { get; set; }

        public static FurnitureGetFurnituresCommand Create(string id)
            => new FurnitureGetFurnituresCommand(id);
    }
}
