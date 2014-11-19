using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public class ValidationAnnotations
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Maximum length is 20. Minimum length is 1.")]
        public string StringProperty
        {
            get;
            set;
        }

        [Range(10, 50, ErrorMessage = "Value must be between 10 and 50")]
        public int IntegerProperty
        {
            get;
            set;
        }
    }
}
