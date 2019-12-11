using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Domain
{
    public class Predictor
    {
        [Required(ErrorMessage = "The plate number is required.")]

        public PlateNumber PlateNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
