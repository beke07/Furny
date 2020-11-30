using Furny.AdFeature.Data;
using Furny.Common.Commands;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureGetAdCommand : GetCommand<AdFeatureAdDto>, IGetSingleElementCommandBase
    {
        public AdFeatureGetAdCommand(string id, string elementId) : base(id)
        {
            ElementId = elementId;
        }

        public string ElementId { get; set; }

        public static AdFeatureGetAdCommand Create(string id, string elementId)
            => new AdFeatureGetAdCommand(id, elementId);
    }
}
