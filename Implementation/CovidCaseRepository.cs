using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using covidAPI.Interface;
using covidAPI.Models;
using covidAPI.Repositories;

namespace covidAPI.Implementation
{
    public class CovidCaseRepository : Repository<CovidCase>, ICovidCaseRepository
    {

        private readonly DataContext context;
        public CovidCaseRepository(DataContext context) : base(context) {
            this.context = context;
        } 

        public async Task<object> GetCovidCases(DateTime dtmObservationDate, int intMaxResults)
        {          
            var data = await context.CovidCases
                                    .Where(t => t.dtmObservationDate == dtmObservationDate)                                    
                                    .GroupBy(g => g.strCountry)                                    
                                    .Select(s => new {
                                        country = s.Max(m => m.strCountry),
                                        confirmed =  s.Sum(c => c.intConfirmed),
                                        deaths =  s.Sum(c => c.intDeaths),
                                        recovered = s.Sum(c => c.intRecovered)
                                    })
                                    .OrderByDescending(x => x.confirmed)
                                    .Take(intMaxResults)
                                    .ToListAsync();

            return new {
                observation_date = dtmObservationDate,
                countries = data
            };
        }
    }
}