using covidAPI.Models;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace covidAPI.Interface
{
    public interface IDataContext
    {
        DbSet<CovidCase> CovidCases { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        //DbSet<T> GetQuery<T>() where T : class;
    }
}