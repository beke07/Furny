using Furny.Common.CommandHandlers;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.ViewModels;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureCreateFurnitureCommandHandler : CreateSingleElementCommandBaseHandler<FurnitureCreateFurnitureCommand, FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        public FurnitureCreateFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
