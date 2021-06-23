using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LoggingLearning.Models
{
    public class FormModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string Username { get; set; }

        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter valid value")]
        public int Age { get; set; }

        [FromQuery]
        public string DataFromQuery { get; set; }
    }
}
