using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Working_with_events_api.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int? id);

        Task Update(T entity);

        Task<IEnumerable<T>> Select();

        Task<T> Insert(T entity);

        Task Delete(T entity);
    }
}
