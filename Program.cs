using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CsvHelper;
using System.IO;
using System.Globalization;
using covidAPI.Mapping;
using covidAPI.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using covidAPI.Implementation;
using covidAPI.Interface;

namespace covidAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            ProcessCSV();
            CreateHostBuilder(args).Build().Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void ProcessCSV() 
        {
            var collection = new ServiceCollection();
            collection.AddDbContext<DataContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=MorganDB;Username=postgres;Password=1234"));
            collection.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            collection.AddScoped<ICovidCaseRepository, CovidCaseRepository>();
            
            var service = collection.BuildServiceProvider();
            var _covidCaseRepository = service.GetService<ICovidCaseRepository>();

            using (var streamReader = new StreamReader(@"csv\covid_19_data.csv")) 
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<CovidCaseMap>();
                    var records = csvReader.GetRecords<CovidCase>().ToList();

                    _covidCaseRepository.AddBatch(records);
                }
            }
        }
    }
}
