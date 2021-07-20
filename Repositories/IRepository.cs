using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace covidAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);
        Task DeleteRange(IEnumerable<TEntity> entities);
        Task Save();
    }
}