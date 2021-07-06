using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingLearning.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingLearning.Binders
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {

            IModelBinder binder = new CustomModelBinder();
            return context.Metadata.ModelType == typeof(FormModel) ? binder : null;
        }
    }
}
