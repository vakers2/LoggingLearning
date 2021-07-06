using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingLearning.Attributes
{
    public class EvenNumberAttribute : ValidationAttribute
    {
        public EvenNumberAttribute(int min = int.MinValue, int max = int.MaxValue)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value is not int)
            {
                return new ValidationResult("Provided value must be number.");
            }

            var number = (int) value;

            if (number % 2 != 0)
            {
                return new ValidationResult("Number must be even.");
            }

            if (number < Min)
            {
                return new ValidationResult($"Number must be greater than {Min}.");
            }

            if (number > Max)
            {
                return new ValidationResult($"Number must be less than {Min}.");
            }


            return ValidationResult.Success;
        }
    }
}
