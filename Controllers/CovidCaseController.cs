using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covidAPI.Interface;
using covidAPI.Models;

namespace covidAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidCaseController : ControllerBase
    {
        private readonly ICovidCaseRepository _covidCaseRepository;
        public CovidCaseController(ICovidCaseRepository covidCaseRepository)
        {
            _covidCaseRepository = covidCaseRepository;
        }

        [HttpGet("{observation_date}/{max_results}")]
        public async Task<ActionResult<IEnumerable<CovidCase>>> GetCovidCases(DateTime observation_date, int max_results)
        {
            var covidCases = await _covidCaseRepository.GetCovidCases(observation_date, max_results);
            
            return Ok(covidCases);
        }
    }
}