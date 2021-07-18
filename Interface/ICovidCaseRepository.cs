using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using covidAPI.Models;

namespace covidAPI.Interface
{
    public interface ICovidCaseRepository
    {
        Task<object> GetCovidCases(DateTime strObservationDate, int intMaxResults);
        Task DeleteAll();
        Task AddBatch(List<CovidCase> covidCases);
    }
}