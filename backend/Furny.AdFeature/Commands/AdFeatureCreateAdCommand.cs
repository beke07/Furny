using Furny.AdFeature.Data;
using Furny.Common.Commands;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureCreateAdCommand : ICreateSingleElementCommandBase<AdFeatureAdDto>
    {
        public AdFeatureCreateAdCommand(string id, AdFeatureAdDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public AdFeatureAdDto Element { get; set; }

        public static AdFeatureCreateAdCommand Create(string id, AdFeatureAdDto element)
            => new AdFeatureCreateAdCommand(id, element);
    }
}
