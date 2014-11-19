using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF.DataAnnotations
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple = true)]
    public class EditorResourceKey : Attribute
    {
        public string Key { get; set; }
    }
}
