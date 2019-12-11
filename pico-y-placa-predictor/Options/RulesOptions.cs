using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Options
{
    public class RulesOptions
    {
        public string ByPlateNumber { get; set; }
        public List<LicensePlateOptions> LincensePlateOptions { get; set; }
        public List<RangesOptions> Ranges { get; set; }
        public List<HolidaysOptions> HolidaysExceptions { get; set; }

    }
}
