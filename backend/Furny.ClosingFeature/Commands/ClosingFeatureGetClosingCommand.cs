using Furny.ClosingFeature.Data;
using Furny.Common.Commands;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureGetClosingCommand : GetCommand<ClosingFeatureClosingDto>, IGetSingleElementCommandBase
    {
        public ClosingFeatureGetClosingCommand(string id, string fid) : base(id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static ClosingFeatureGetClosingCommand Create(string id, string fid)
            => new ClosingFeatureGetClosingCommand(id, fid);
    }
}
