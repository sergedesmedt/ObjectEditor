using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public class CategorizedProperties
    {
        public string StringProperty1
        {
            get;
            set;
        }

        public int IntegerProperty2
        {
            get;
            set;
        }

        [Category("Cat1")]
        public string StringProperty3
        {
            get;
            set;
        }

        [Category("Cat1")]
        public int IntegerProperty4
        {
            get;
            set;
        }
    }
}
