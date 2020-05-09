using Furny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IBaseService<T>
        where T : IMongoEntityBase
    {
        Task<T> FindByIdAsync(string id);
    }
}
