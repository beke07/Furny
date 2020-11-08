using MediatR;

namespace Furny.Common.Commands
{
    public interface ICreateSingleElementCommandBase<D> : IRequest
    {
        public string Id { get; set; }

        public D Element { get; set; }
    }
}
