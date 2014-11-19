using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace HFK.ObjectEditor.WPF.Validators
{
    public class IntegerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
           ValidationResult result = new ValidationResult(true, null);

            int intValue;
            if(!int.TryParse((string)value, out intValue))
            {
                result = new ValidationResult(false, "Not an integer value");
            }

            return result;
        }
    }
}
