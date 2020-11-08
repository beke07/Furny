using Furny.Common.Commands;
using Furny.Common.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.Common.CommandHandlers
{
    public class RemoveSingleElementCommandBaseHandler<C, D, TD> : IRequestHandler<C>
        where C : IRemoveSingleElementCommandBase, IRequest
        where D : class
        where TD : TableBaseViewModel
    {
        private readonly ISingleElementService<D, TD> _singleElementService;

        public RemoveSingleElementCommandBaseHandler(ISingleElementService<D, TD> singleElementService)
        {
            _singleElementService = singleElementService;
        }

        public async Task<Unit> Handle(C request, CancellationToken cancellationToken)
        {
            await _singleElementService.RemoveAsync(request.Id, request.ElementId);

            return Unit.Value;
        }
    }
}
