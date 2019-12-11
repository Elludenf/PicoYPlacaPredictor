using PicoYPlacaPredictor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Services
{
    public interface IPredictorService
    {
        Task<bool> CanCarDrive(Predictor predictor);

    }
}
