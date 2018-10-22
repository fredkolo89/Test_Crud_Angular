using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        //IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        //void Add(T entity);

        //void Delete(T entity);

        //void Edit(T entity);

        //void Save();
    }
}
