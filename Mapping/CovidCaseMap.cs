using covidAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace covidAPI.Mapping
{
    public class CovidCaseMap : ClassMap<CovidCase>
    {
        public CovidCaseMap()
        {
            Map(m => m.intId).Name("SNo");
            Map(m => m.dtmObservationDate).Name("ObservationDate");
            Map(m => m.dtmLastUpdate).Name("Last Update");
            Map(m => m.strProvince).Name("Province/State");
            Map(m => m.strCountry).Name("Country/Region");
            Map(m => m.intConfirmed).Name("Confirmed");
            Map(m => m.intDeaths).Name("Deaths");
            Map(m => m.intRecovered).Name("Recovered");
        }
    }
}