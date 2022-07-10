using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working_with_events_api.Domain;

namespace Working_with_events_api.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetBySpiker(object obj);

        Task InsertSomeValues(IEnumerable<Event> products);
    }
}
