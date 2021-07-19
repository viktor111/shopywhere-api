using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopyWhere.API.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {

        protected AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task<T> Add(T entity)
        {
            var entityAddedResult = await _dbContext.AddAsync(entity);

            await SaveChanges();

            return entityAddedResult.Entity;
        }

        public async virtual Task<IEnumerable<T>> All()
        {
            var entitySet = await _dbContext.Set<T>()
                .ToListAsync();

            return entitySet;
        }

        public virtual Task<T> Delete(T entity)
        {
            return Task.Run(() =>
            {
                _dbContext.Remove(entity);

                return Task.FromResult(entity);
            });
        }

        public async virtual Task<IEnumerable<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var entitySet = await _dbContext.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();

            return entitySet;
        }

        public async virtual Task<T> Get(int id)
        {
            var entity = await _dbContext.FindAsync<T>();

            return entity;
        }

        public async virtual Task<T> GetSingleByProperty(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var entity = await _dbContext
                .Set<T>()
                .FirstOrDefaultAsync(predicate);

            return entity;
        }

        public async virtual Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public virtual Task<T> Update(T entity)
        {
            return Task.Run(() =>
            {
                var updatedEntity = _dbContext
               .Update(entity).Entity;

                return Task.FromResult(entity);
            });           
        }
    }
}
