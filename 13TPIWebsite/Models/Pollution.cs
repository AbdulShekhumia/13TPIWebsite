using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Pollution
    {
        public int PollutionID { get; set; }
        [Required(ErrorMessage = "The Country field is Required")]
        public string Country { get; set; }
        [Display(Name = "Average Temperature")]
        public float AvgTemperature { get; set; }
        public int Population { get; set; }
        [Display(Name = "Pollution Levels")]
        public int PollutionLevels { get; set; }
        [Display(Name = "Carbon Emissions")]
        public int CarbonEmissions { get; set; }
    }
}
