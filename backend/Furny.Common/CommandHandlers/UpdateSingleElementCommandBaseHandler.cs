using Furny.Common.Commands;
using Furny.Common.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.Common.CommandHandlers
{
    public class UpdateSingleElementCommandBaseHandler<C, D, TD> : IRequestHandler<C>
        where C : IUpdateSingleElementCommandBase<D>, IRequest
        where D : class
        where TD : TableBaseViewModel
    {
        private readonly ISingleElementService<D, TD> _singleElementService;

        public UpdateSingleElementCommandBaseHandler(ISingleElementService<D, TD> singleElementService)
        {
            _singleElementService = singleElementService;
        }

        public async Task<Unit> Handle(C request, CancellationToken cancellationToken)
        {
            await _singleElementService.UpdateAsync(request.Patch, request.Id, request.ElementId);

            return Unit.Value;
        }
    }
}
