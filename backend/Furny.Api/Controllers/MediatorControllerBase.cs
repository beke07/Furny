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

        public async Task SendAsync(INotification command)
        {
            await _mediator.Publish(command);
        }
    }
}
