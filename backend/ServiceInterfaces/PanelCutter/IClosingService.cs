using Furny.Data;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IClosingService : ISingleElementService<ClosingDto, ClosingTableDto>
    { }
}
