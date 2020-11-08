using Furny.ClosingFeature.Data;
using Furny.Common.Commands;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.ClosingFeature.Commands
{
    public class ClosingFeatureUpdateClosingCommand : UpdateCommand<ClosingFeatureClosingDto>, IUpdateSingleElementCommandBase<ClosingFeatureClosingDto>
    {
        public ClosingFeatureUpdateClosingCommand(JsonPatchDocument<ClosingFeatureClosingDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static ClosingFeatureUpdateClosingCommand Create(JsonPatchDocument<ClosingFeatureClosingDto> patch, string id, string fid)
            => new ClosingFeatureUpdateClosingCommand(patch, id, fid);
    }
}
