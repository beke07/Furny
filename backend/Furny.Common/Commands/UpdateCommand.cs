using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.Common.Commands
{
    public class UpdateCommand<T> : IRequest
        where T : class
    {
        public UpdateCommand(JsonPatchDocument<T> patch, string id)
        {
            Patch = patch;
            Id = id;
        }

        public JsonPatchDocument<T> Patch { get; set; }

        public string Id { get; set; }
    }
}
