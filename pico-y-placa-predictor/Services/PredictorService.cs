using Microsoft.Extensions.Configuration;
using PicoYPlacaPredictor.Domain;
using PicoYPlacaPredictor.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Services
{
    public class PredictorService: IPredictorService
    {
        public PredictorService(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }
        
        //TODO: REFACTOR LOGIC , TEST WITH HOLIDAYS, ADD WITH RESTRICTION BY DAY AND LAST DIGIT
        public async Task<bool> CanCarDrive(Predictor predictor)
        {
            var picoYPlacaOptions = new PicoYPlacaOptions();
            Configuration.GetSection(nameof(PicoYPlacaOptions)).Bind(picoYPlacaOptions);

            var dateToValidate = predictor.Date;
            foreach (var holiday in picoYPlacaOptions.Rules.HolidaysExceptions)
            {
                var holidayInfo = holiday.Date.ToString().Split("/");
                var holidayDate = new DateTime(Int32.Parse(holidayInfo[0]), Int32.Parse(holidayInfo[1]), DateTime.Now.Year);

                if ((holidayDate.Day == dateToValidate.Day && holidayDate.Month == dateToValidate.Month))
                {
                    return true;
                }
            }

            foreach (var item in picoYPlacaOptions.Rules.LincensePlateOptions)
            {
                // TODO: FINISH LOGIC BY LAST PLATE NUMBER 
                if(item.Day == predictor.Date.ToString("ddd") && predictor.PlateNumber.Number.ToString() == "1")
                {

                }
            }

           
            return true;
        }

        

    }
}
