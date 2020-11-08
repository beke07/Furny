using Furny.Common.CommandHandlers;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.ViewModels;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureUpdateFurnitureCommandHandler : UpdateSingleElementCommandBaseHandler<DesignerFurnitureUpdateFurnitureCommand, DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>
    {
        public DesignerFurnitureUpdateFurnitureCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
