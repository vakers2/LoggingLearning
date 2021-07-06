using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;

namespace LoggingLearning.Attributes
{
    public class EvenNumberAttributeAdapter : AttributeAdapterBase<EvenNumberAttribute>
    {
        public EvenNumberAttributeAdapter(EvenNumberAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-age", GetErrorMessage(context));

            var min = Attribute.Min.ToString(CultureInfo.InvariantCulture);
            var max = Attribute.Max.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-age-min", min);
            MergeAttribute(context.Attributes, "data-val-age-max", max);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext) =>
            Attribute.GetErrorMessage();
    }
}
