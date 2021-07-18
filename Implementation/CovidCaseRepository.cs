using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using covidAPI.Interface;
using covidAPI.Models;

namespace covidAPI.Implementation
{
    public class CovidCaseRepository : ICovidCaseRepository
    {
        private readonly IDataContext _context;
        public CovidCaseRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<object> GetCovidCases(DateTime strObservationDate, int intMaxResults)
        {           
            
            //_context.GetQuery<CovidCase>()
            var data = await _context.CovidCases.FindAsync(3);//.ToListAsync();

            return new {
                observation_date = strObservationDate,
                countries = data
            };
        }
        public async Task AddBatch(List<CovidCase> covidCases)
        {
            foreach(var covidCase in covidCases)
            {
                _context.CovidCases.Add(covidCase);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll()
        {
            var records = await _context.CovidCases.ToListAsync();

            _context.CovidCases.RemoveRange(records);
            await _context.SaveChangesAsync();
        }
    }
}