using MediatR;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public class MediatorControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public MediatorControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<T> SendAsync<T>(IRequest<T> command)
        {
            return await _mediator.Send(command);
        }
    }
}
