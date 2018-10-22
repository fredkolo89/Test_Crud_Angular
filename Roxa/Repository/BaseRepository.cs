using Microsoft.EntityFrameworkCore;
using Roxa.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();

        }

        //public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        //{
        //    IQueryable<T> query = _context.Set<T>().Where(predicate);
        //    return query;
        //}

        //public virtual void Add(T entity)
        //{
        //    _context.Set<T>().Add(entity);
        //}

        //public virtual void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        //public virtual void Edit(T entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //}

        //public virtual void Save()
        //{
        //    _context.SaveChanges();
        //}
    }
}
