using MediatR;
using System;

namespace Furny.Common.Commands
{
    public class TableBaseCommand : IRequest
    {
        public string _id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
