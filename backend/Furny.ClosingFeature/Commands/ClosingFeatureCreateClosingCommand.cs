using Furny.ClosingFeature.Data;
using Furny.Common.Commands;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureCreateClosingCommand : ICreateSingleElementCommandBase<ClosingFeatureClosingDto>
    {
        public ClosingFeatureCreateClosingCommand(string id, ClosingFeatureClosingDto element)
        {
            Id = id;
            Element = element;
        }

        public string Id { get; set; }

        public ClosingFeatureClosingDto Element { get; set; }

        public static ClosingFeatureCreateClosingCommand Create(string id, ClosingFeatureClosingDto element)
            => new ClosingFeatureCreateClosingCommand(id, element);
    }
}
