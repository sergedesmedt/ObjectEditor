using System;
using System.Collections.Generic;
using System.Text;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public enum CustomEnum
    {
        EnumValue1,
        EnumValue2,
        EnumValue3
    }

    [Flags]
    public enum CustomFlag
    {
        FlagValue1 = 1,
        FlagValue2 = 2,
        FlagValue3 = 4
    }

    public class SimpleProperties
    {
        public string StringProperty
        {
            get;
            set;
        }

        public int IntegerProperty
        {
            get;
            set;
        }

        public bool BooleanProperty
        {
            get;
            set;
        }

        public CustomEnum EnumProperty
        {
            get;
            set;
        }

        public CustomFlag FlagProperty
        {
            get;
            set;
        }
    }
}
