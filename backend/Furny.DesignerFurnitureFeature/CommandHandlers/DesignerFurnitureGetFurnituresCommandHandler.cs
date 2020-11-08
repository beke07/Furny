using Furny.Common.CommandHandlers;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.ViewModels;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureGetFurnituresCommandHandler : GetSingleElementsCommandBaseHandler<DesignerFurnitureGetFurnituresCommand, DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>
    {
        public DesignerFurnitureGetFurnituresCommandHandler(IFurnitureService furnitureService) : base(furnitureService)
        { }
    }
}
