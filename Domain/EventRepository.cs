using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Domain
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EventRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<Event>> Select()
        {
            return await _applicationDbContext.Events.ToListAsync();
        }

        public async Task<Event> Get(int? id)
        {
            return await _applicationDbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Event> GetBySpiker(object name)
        {
            return await _applicationDbContext.Events.FirstOrDefaultAsync(x => x.Spiker == name);
        }

        public async Task<Event> Insert(Event product)
        {
            await _applicationDbContext.Events.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task InsertSomeValues(IEnumerable<Event> products)
        {
            _applicationDbContext.Events.AddRange(products);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(Event product)
        {
            _applicationDbContext.Events.Remove(product);
             await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(Event product)
        {
            _applicationDbContext.Events.Update(product);
             await _applicationDbContext.SaveChangesAsync();
        }
    }
}
