using Furny.Common.Commands;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureRemoveAdCommand : IRemoveSingleElementCommandBase
    {
        public AdFeatureRemoveAdCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static AdFeatureRemoveAdCommand Create(string id, string elementId)
            => new AdFeatureRemoveAdCommand(id, elementId);
    }
}
