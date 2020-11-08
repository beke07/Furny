using Furny.Common.Commands;
using Furny.DesignerFurnitureFeature.Data;

namespace Furny.DesignerFurnitureFeature.Commands
{
    public class DesignerFurnitureCreateFurnitureCommand : ICreateSingleElementCommandBase<DesignerFurnitureFurnitureDto>
    {
        public DesignerFurnitureCreateFurnitureCommand(string id, DesignerFurnitureFurnitureDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public DesignerFurnitureFurnitureDto Element { get; set; }

        public static DesignerFurnitureCreateFurnitureCommand Create(string id, DesignerFurnitureFurnitureDto element)
            => new DesignerFurnitureCreateFurnitureCommand(id, element);
    }
}
