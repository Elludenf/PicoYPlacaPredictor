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
        //private readonly IUriService _uriService;
        public PredictorController(IPredictorService predictorService) {
            _predictorService = predictorService;
                
        }
        [HttpPost(ApiRoutes.Predictor.Validate)]
        public async Task<IActionResult> Validate([FromBody] Predictor Predictor)
        {
            //var newPostId = Guid.NewGuid();
            /*
            var post = new Post
            {
                Id = newPostId,
                Name = postRequest.Name,
                UserId = HttpContext.GetUserId(),
                Tags = postRequest.Tags.Select(x => new PostTag { PostId = newPostId, TagName = x }).ToList()
            };
            await _postService.CreatePostAsync(post);
            */
            //var locationUri = _uriService.GetPostUri(post.Id.ToString());
            var result = await _predictorService.CanCarDrive(Predictor);

            var plate = Predictor.PlateNumber;
            if (ModelState.IsValid)
            {
                //Validate Informacion
                //var plateNumberService = new PlateNumberService();
                //var lastDigitPlate = plateNumber.plate[plateNumber.plate.Length - 1];
                //var dayWeek = plateNumber.dateToCheck.ToString("ddd");
                //DateTime convertHour = MergeHourToday(plateNumber.timeToCheck);


                //var result = plateNumberService.getResult(lastDigitPlate, dayWeek, convertHour);


                //return View(plateNumber);
                return Ok(new { Response = "valid" });

            }
            //return RedirectToAction("Index");
            return Ok(new { Response = "valid" });
        }

    }
}