using Furny.Common.Commands;

namespace Furny.FurnitureFeature.Commands
{
    public class FurnitureRemoveFurnitureCommand : IRemoveSingleElementCommandBase
    {
        public FurnitureRemoveFurnitureCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static FurnitureRemoveFurnitureCommand Create(string id, string elementId)
            => new FurnitureRemoveFurnitureCommand(id, elementId);
    }
}
