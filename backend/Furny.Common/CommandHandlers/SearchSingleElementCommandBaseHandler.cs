using Furny.Common.Commands;
using Furny.Common.ServiceInterfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.Common.CommandHandlers
{
    public class SearchSingleElementCommandBaseHandler<C, D, TD> : IRequestHandler<C, IList<TD>>
        where C : ISearchSingleElementCommandBase<TD>, IRequest<IList<TD>>
        where D : class
        where TD : TableBaseViewModel
    {
        private readonly ISingleElementService<D, TD> _singleElementService;

        public SearchSingleElementCommandBaseHandler(ISingleElementService<D, TD> singleElementService)
        {
            _singleElementService = singleElementService;
        }

        public async Task<IList<TD>> Handle(C request, CancellationToken cancellationToken)
        {
            return await _singleElementService.QuickSearchAsync(request.Id, request.Term, request.PropertyName);
        }
    }
}
