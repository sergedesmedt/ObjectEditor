using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public enum EnumWithDisplay
    {
        [Display(Name = "DisplayEnumValue1")]
        EnumValue1,
        [Display(Name = "DisplayEnumValue2")]
        EnumValue2
    }

    public class DisplayAnnotations
    {
        [Browsable(false)]
        public String HiddenProperty
        {
            get;
            set;
        }

        [DisplayName("DisplayStringProperty")]
        [Description("A description of the property.")]
        public string StringProperty
        {
            get;
            set;
        }

        public EnumWithDisplay DisplayEnumProperty
        {
            get;
            set;
        }

        public int IntegerProperty
        {
            get;
            set;
        }
    }
}
