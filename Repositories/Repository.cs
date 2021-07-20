using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace covidAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
     
        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        
        public async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }
        
        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            
            await Context.SaveChangesAsync();
        }
        public async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            
            await Context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        //public DbSet<TEntity> CovidCases { get; set; }
    }
}