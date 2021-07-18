using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace covidAPI.Interface
{
    public interface IRepository
    {
        DbSet<T> GetQuery<T>() where T : class;
        //Task<int> SaveAsync(bool continueOnConflict);
    }
}