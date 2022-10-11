using AdventureWorksSales.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksSales.Core.Concrete
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : class, new()
    {
        protected AdventureWorksSalesEntities _context = new AdventureWorksSalesEntities();

        // Get Entity by Id
        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Get All Entities
        public IQueryable<T> Query()
        {

            return _context.Set<T>().AsQueryable();
        }

        // Save Entity Into Database
        public async Task InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        // Delete Entity From Database
        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Update Entity 
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
