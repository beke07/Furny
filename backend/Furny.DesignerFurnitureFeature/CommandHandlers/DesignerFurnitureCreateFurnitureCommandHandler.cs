using Furny.Common.CommandHandlers;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.ViewModels;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureCreateFurnitureCommandHandler : CreateSingleElementCommandBaseHandler<DesignerFurnitureCreateFurnitureCommand, DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>
    {
        public DesignerFurnitureCreateFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
