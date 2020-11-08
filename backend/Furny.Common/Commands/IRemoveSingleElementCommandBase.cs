using MediatR;

namespace Furny.Common.Commands
{
    public interface IRemoveSingleElementCommandBase : IRequest
    {
        public string Id { get; set; }

        public string ElementId { get; set; }
    }
}
