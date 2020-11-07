using MediatR;

namespace Furny.Common.Commands
{
    public class GetCommand<T> : IRequest<T>
    {
        public GetCommand()
        { }

        public GetCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
