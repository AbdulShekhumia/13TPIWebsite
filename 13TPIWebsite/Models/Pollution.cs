using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalDatabase.Models
{
    public class Pollution
    {
        public int PollutionID { get; set; }
        public string Country { get; set; }
        public float AvgTemperature { get; set; }
        public int Population { get; set; }
        public int PollutionLevels { get; set; }
        public int CarbonEmissions { get; set; }
    }
}
