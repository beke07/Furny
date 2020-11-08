using MediatR;
using System.Collections.Generic;

namespace Furny.Common.Commands
{
    public interface ISearchSingleElementCommandBase<TD> : IRequest<IList<TD>>
    {
        public string Id { get; set; }

        public string Term { get; set; }

        public string PropertyName { get; set; }
    }
}
