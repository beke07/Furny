using Furny.Common.CommandHandlers;
using Furny.FurnitureFeature.Data;
using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.ViewModels;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureUpdateFurnitureCommandHandler : UpdateSingleElementCommandBaseHandler<FurnitureUpdateFurnitureCommand, FurnitureFurnitureDto, FurnitureFurnitureTableViewModel>
    {
        public FurnitureUpdateFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
