using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HFK.ObjectEditor.WPF.DataAnnotations;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public class AllowedValues
    {
        [AllowedStringValue(Value = "AllowedValue1", DisplayValue = "DisplayAllowedValue1")]
        [AllowedStringValue(Value = "AllowedValue2")]
        [AllowedStringValue(Value = "AllowedValue3", DisplayValue = "DisplayAllowedValue3")]
        public string LimitedStringValue
        {
            get;
            set;
        }
    }
}
