using Furny.Common.CommandHandlers;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.ViewModels;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureGetFurnituresCommandHandler : GetSingleElementsCommandBaseHandler<FurnitureGetFurnituresCommand, FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        public FurnitureGetFurnituresCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
