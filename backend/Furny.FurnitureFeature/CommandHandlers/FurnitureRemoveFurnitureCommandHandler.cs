using Furny.Common.CommandHandlers;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.ViewModels;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureRemoveFurnitureCommandHandler : RemoveSingleElementCommandBaseHandler<FurnitureRemoveFurnitureCommand, FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        public FurnitureRemoveFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
