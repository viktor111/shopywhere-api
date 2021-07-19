using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopyWhere.API.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Get(int id);

        Task<T> Delete(T entity);

        Task<T> GetSingleByProperty(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> All();

        Task<bool> SaveChanges();
    }
}
