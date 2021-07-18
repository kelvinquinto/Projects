using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace covidAPI.Models
{  
    [Table("covid_observation")]
    public class CovidCase
    {
        [Key]
        public int intId { get; set; }
        public DateTime dtmObservationDate { get; set; }
        public DateTime dtmLastUpdate { get; set; }
        public string strProvince { get; set; }
        public string strCountry { get; set; }        
        public int intConfirmed { get; set; }
        public int intDeaths { get; set; }
        public int intRecovered { get; set; }
    }
}