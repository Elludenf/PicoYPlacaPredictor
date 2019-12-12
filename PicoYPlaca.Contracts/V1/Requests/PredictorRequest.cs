using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tweetbook.Contracts.V1.Requests
{
    public class PredictorRequest
    {
        [Required(ErrorMessage = "The plate number is required.")]
        [RegularExpression(@"[a-z]{3}-[0-9]{4}", ErrorMessage = "Invalid plate number.")]
        public string PlateNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
