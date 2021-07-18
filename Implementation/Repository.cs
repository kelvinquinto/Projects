using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using covidAPI.Interface;

namespace covidAPI.Implementation
{
    public class Repository<TEntity> : IRepository
    {
        private DbContext _context;
     
        public Repository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> GetQuery<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}