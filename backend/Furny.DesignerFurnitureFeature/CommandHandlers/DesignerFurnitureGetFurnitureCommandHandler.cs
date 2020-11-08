using Furny.Common.CommandHandlers;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.ViewModels;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureGetFurnitureCommandHandler : GetSingleElementCommandBaseHandler<DesignerFurnitureGetFurnitureCommand, DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>
    {
        public DesignerFurnitureGetFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
