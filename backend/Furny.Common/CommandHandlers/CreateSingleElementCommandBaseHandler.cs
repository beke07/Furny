using Furny.Common.Commands;
using Furny.Common.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.Common.CommandHandlers
{
    public class CreateSingleElementCommandBaseHandler<C, D, TD> : IRequestHandler<C>
        where C : ICreateSingleElementCommandBase<D>, IRequest
        where D : class
        where TD : TableBaseViewModel
    {
        private readonly ISingleElementService<D, TD> _singleElementService;

        public CreateSingleElementCommandBaseHandler(ISingleElementService<D, TD> singleElementService)
        {
            _singleElementService = singleElementService;
        }

        public async Task<Unit> Handle(C request, CancellationToken cancellationToken)
        {
            await _singleElementService.CreateAsync(request.Element, request.Id);

            return Unit.Value;
        }
    }
}
