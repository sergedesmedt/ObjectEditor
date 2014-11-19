using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF.DataAnnotations
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple = true)]
    public class AllowedStringValue : Attribute
    {
        public string DisplayValue { get; set; }
        public string Value { get; set; }
    }
}
