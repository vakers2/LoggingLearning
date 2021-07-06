using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
                return new ValidationResult($"Number must be less than {Max}.");
            }


            return ValidationResult.Success;
        }

        internal string GetErrorMessage()
        {
            var stringBuilder = new StringBuilder("Number must be even. ");
            if (Min != int.MinValue)
            {
                stringBuilder.Append($"Number must be equal or greater than {Min}. ");
            } 
            
            if (Max != int.MaxValue)
            {
                stringBuilder.Append($"Number must be equal or less than {Max}. ");
            }


            return stringBuilder.ToString();
        }
    }
}
