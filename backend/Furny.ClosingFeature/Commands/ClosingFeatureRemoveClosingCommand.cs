using Furny.Common.Commands;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureRemoveClosingCommand : IRemoveSingleElementCommandBase
    {
        public ClosingFeatureRemoveClosingCommand(string id, string elementId)
        {
            Id = id;
            ElementId = elementId;
        }

        public string Id { get; set; }

        public string ElementId { get; set; }

        public static ClosingFeatureRemoveClosingCommand Create(string id, string elementId)
            => new ClosingFeatureRemoveClosingCommand(id, elementId);
    }
}
