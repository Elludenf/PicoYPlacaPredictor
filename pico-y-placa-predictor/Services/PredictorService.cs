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
            if (picoYPlacaOptions.Rules.HolidaysExceptions.Select(holiday => holiday.Date.ToString().Split("/"))
                .Select(holidayInfo =>
                    new DateTime(DateTime.Now.Year, Int32.Parse(holidayInfo[0]), Int32.Parse(holidayInfo[1])))
                .Any(holidayDate =>
                    (holidayDate.Day == dateToValidate.Day && holidayDate.Month == dateToValidate.Month)))
            {
                return true;
            }

            string licencePlate = predictor.PlateNumber;
            string lastDigit = licencePlate.Substring(licencePlate.Length - 1);
            if (picoYPlacaOptions.Rules.LincensePlateOptions.Any(item =>
                item.Day == predictor.Date.ToString("ddd") &&
                Array.Exists(item.Digits, digit => digit == Int32.Parse(lastDigit))))
            {
                return !(
                    from range in picoYPlacaOptions.Rules.Ranges
                    let fromTime = range.From.Replace(":", String.Empty)
                    let toTime = range.To.Replace(":", String.Empty)
                    let timeToValidate = dateToValidate.ToString("HH:mm").Replace(":", String.Empty)
                    where Convert.ToInt32(timeToValidate) >= Convert.ToInt32(fromTime) &&
                          Convert.ToInt32(timeToValidate) <= Int32.Parse(toTime)
                    select fromTime).Any();
            }

            return true;
        }
    }
}