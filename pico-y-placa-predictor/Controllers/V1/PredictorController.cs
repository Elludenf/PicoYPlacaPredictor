using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicoYPlacaPredictor.Domain;
using PicoYPlacaPredictor.Services;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;

namespace PicoYPlacaPredictor.Controllers.V1
{
    [Produces("application/json")]
    public class PredictorController : Controller
    {
        private readonly IPredictorService _predictorService;
        public PredictorController(IPredictorService predictorService) {
            _predictorService = predictorService;
                
        }
        /// <summary>
        /// Predictor Validator for Pico y Placa 
        /// </summary>
        /// <param name="Predictor"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Predictor.Validate)]
        public async Task<IActionResult> Validate([FromBody] Predictor Predictor)
        {
            if (ModelState.IsValid)
            {
                var result = await _predictorService.CanCarDrive(Predictor);

                if (result)
                {
                    return Ok(new { Result =  "Car is free to ride"});

                }
                return Ok(new { Result = "Car cannot ride in the given date"});

            }
            return BadRequest(new { Response = "Invalid Request" });
        }
    }
}