using Furny.Common.CommandHandlers;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.ViewModels;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureGetFurnitureCommandHandler : GetSingleElementCommandBaseHandler<FurnitureGetFurnitureCommand, FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        public FurnitureGetFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
