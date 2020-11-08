using Furny.AdFeature.Data;
using Furny.Common.Commands;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.AdFeature.Commands
{
    public class AdFeatureUpdateAdCommand : UpdateCommand<AdFeatureAdDto>, IUpdateSingleElementCommandBase<AdFeatureAdDto>
    {
        public AdFeatureUpdateAdCommand(JsonPatchDocument<AdFeatureAdDto> patch, string id, string fid) : base(patch, id)
        {
            ElementId = fid;
        }

        public string ElementId { get; set; }

        public static AdFeatureUpdateAdCommand Create(JsonPatchDocument<AdFeatureAdDto> patch, string id, string fid)
            => new AdFeatureUpdateAdCommand(patch, id, fid);
    }
}
