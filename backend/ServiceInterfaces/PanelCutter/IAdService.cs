using Furny.Data;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAdService : ISingleElementService<AdDto, AdTableDto>
    { }
}
