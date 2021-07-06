using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LoggingLearning.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LoggingLearning.Models
{
    public class FormModel : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Username { get; set; }

        public string Name { get; set; }

        [EvenNumber(0, 100, ErrorMessage = "Number must be even in range between 0 and 100.")]
        public int Age { get; set; }

        [FromQuery]
        public string DataFromQuery { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name field is required.");
            }
        }
    }
}
