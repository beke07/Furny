using Microsoft.AspNetCore.JsonPatch;

namespace Furny.Common.Commands
{
    public interface IUpdateSingleElementCommandBase<T> : IGetSingleElementCommandBase
        where T : class
    {
        public JsonPatchDocument<T> Patch { get; set; }
    }
}
