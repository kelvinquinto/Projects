using covidAPI.Interface;
using covidAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace covidAPI.Implementation
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<CovidCase> CovidCases { get; set; }
    }
}