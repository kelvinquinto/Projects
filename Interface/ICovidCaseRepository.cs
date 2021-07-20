using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using covidAPI.Models;
using covidAPI.Repositories;

namespace covidAPI.Interface
{
    public interface ICovidCaseRepository : IRepository<CovidCase>
    {
        Task<object> GetCovidCases(DateTime strObservationDate, int intMaxResults);
    }
}