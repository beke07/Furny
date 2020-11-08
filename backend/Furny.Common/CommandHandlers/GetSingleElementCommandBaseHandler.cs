using Furny.Common.Commands;
using Furny.Common.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.Common.CommandHandlers
{
    public class GetSingleElementCommandBaseHandler<C, D, TD> : IRequestHandler<C, D>
        where C : IGetSingleElementCommandBase, IRequest<D>
        where D : class
        where TD : TableBaseViewModel
    {
        private readonly ISingleElementService<D, TD> _singleElementService;

        public GetSingleElementCommandBaseHandler(ISingleElementService<D, TD> singleElementService)
        {
            _singleElementService = singleElementService;
        }

        public async Task<D> Handle(C request, CancellationToken cancellationToken)
        {
            return await _singleElementService.GetByIdAsync(request.Id, request.ElementId);
        }
    }
}
