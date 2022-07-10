using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Working_with_events_api.Repositories;

namespace Working_with_events_api.Domain
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Event>> Select()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Events.ToListAsync();
            }
        }

        public async Task<Event> Get(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Events.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Event> GetBySpiker(object name)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Events.FirstOrDefaultAsync(x => x.Spiker == name);
            }
        }

        public async Task<Event> Insert(Event product)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Events.AddAsync(product);
                await db.SaveChangesAsync();
                return product;
            }
        }

        public async Task InsertSomeValues(IEnumerable<Event> products)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Events.AddRange(products);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Event product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Events.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task Update(Event product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Events.Update(product);
                await db.SaveChangesAsync();
            }
        }
    }
}
