﻿using Furny.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IBaseService<T>
        where T : IMongoEntityBase
    {
        Task<T> FindByIdAsync(string id);

        Task UpdateAsync(T entity);

        Task<IList<T>> Get();
    }
}
