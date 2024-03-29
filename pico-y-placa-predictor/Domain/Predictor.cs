﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PicoYPlacaPredictor.Domain
{
    public class Predictor
    {
        [Required(ErrorMessage = "The plate number is required.")]
        [RegularExpression(@"[a-z]{3}-[0-9]{4}", ErrorMessage = "Invalid plate number.")]
        public string PlateNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
