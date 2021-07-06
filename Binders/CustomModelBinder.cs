using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingLearning.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LoggingLearning.Binders
{
    public class CustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var usernameResult = bindingContext.ValueProvider.GetValue("username");
            var ageResult = bindingContext.ValueProvider.GetValue("age");
            var nameResult = bindingContext.ValueProvider.GetValue("name");

            if (usernameResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            if (!int.TryParse(ageResult.FirstValue, out var number))
            {
                bindingContext.ModelState.TryAddModelError(
                    "age", "Invalid value for age field.");

                return Task.CompletedTask;
            }

            var result = new FormModel
            {
                Username = usernameResult.FirstValue,
                Age = number,
                Name = nameResult.FirstValue,
                DataFromQuery = "None"
            };

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
