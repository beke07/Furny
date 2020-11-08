using Furny.Common.Commands;
using Furny.FurnitureFeature.Data;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureCreateFurnitureCommand : ICreateSingleElementCommandBase<FurnitureFurnitureDto>
    {
        public FurnitureCreateFurnitureCommand(string id, FurnitureFurnitureDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public FurnitureFurnitureDto Element { get; set; }

        public static FurnitureCreateFurnitureCommand Create(string id, FurnitureFurnitureDto element)
            => new FurnitureCreateFurnitureCommand(id, element);
    }
}
