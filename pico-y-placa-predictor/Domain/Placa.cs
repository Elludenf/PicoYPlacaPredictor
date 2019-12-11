using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PicoYPlacaPredictor.Domain
{
    public class PlateNumber
    {
        [RegularExpression(@"[a-z]{3}-[0-9]{4}", ErrorMessage = "Invalid plate number.")]
        public string Number { get; set; }

    }
}
