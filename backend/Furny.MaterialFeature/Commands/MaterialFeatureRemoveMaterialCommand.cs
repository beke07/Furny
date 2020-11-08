using Furny.Common.Commands;

namespace Furny.MaterialFeature.Commands
{
    public class MaterialFeatureRemoveMaterialCommand : IRemoveSingleElementCommandBase
    {
        public MaterialFeatureRemoveMaterialCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static MaterialFeatureRemoveMaterialCommand Create(string id, string elementId)
            => new MaterialFeatureRemoveMaterialCommand(id, elementId);
    }
}
