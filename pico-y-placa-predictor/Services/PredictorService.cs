using Microsoft.Extensions.Configuration;
using PicoYPlacaPredictor.Domain;
using PicoYPlacaPredictor.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Services
{
    public class PredictorService : IPredictorService
    {
        public PredictorService(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Service to determine wheter car can drive with given licence plate and date
        /// The logic excludes holidays
        /// And takes into consideration rules on environments settings
        /// </summary>
        /// <param name="predictor"></param>
        /// <returns></returns>
        public async Task<bool> CanCarDrive(Predictor predictor)
        {
            var picoYPlacaOptions = new PicoYPlacaOptions();
            Configuration.GetSection(nameof(PicoYPlacaOptions)).Bind(picoYPlacaOptions);

            var dateToValidate = predictor.Date;
            foreach (var holiday in picoYPlacaOptions.Rules.HolidaysExceptions)
            {
                var holidayInfo = holiday.Date.ToString().Split("/");
                var holidayDate = new DateTime(DateTime.Now.Year, Int32.Parse(holidayInfo[0]), Int32.Parse(holidayInfo[1]));

                if ((holidayDate.Day == dateToValidate.Day && holidayDate.Month == dateToValidate.Month))
                {
                    return true;
                }
            }
            string licencePlate = predictor.PlateNumber;
            string lastDigit = licencePlate.Substring(licencePlate.Length - 1);
            foreach (var item in picoYPlacaOptions.Rules.LincensePlateOptions)
            {
                if (item.Day == predictor.Date.ToString("ddd") && Array.Exists(item.Digits, digit => digit == Int32.Parse(lastDigit)))
                {
                    foreach (var range in picoYPlacaOptions.Rules.Ranges)
                    {
                        var fromTime = range.From.Replace(":", String.Empty);
                        var toTime = range.To.Replace(":", String.Empty);

                        var timeToValidate = dateToValidate.ToString("HH:mm").Replace(":", String.Empty);
                        if (Int32.Parse(timeToValidate) >= Int32.Parse(fromTime) && Int32.Parse(timeToValidate) <= Int32.Parse(toTime))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return true;
        }



    }
}
