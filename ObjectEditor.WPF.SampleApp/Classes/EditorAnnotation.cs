using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using HFK.ObjectEditor.WPF.DataAnnotations;
using HFK.ObjectEditor.WPF.SampleApp.TypeEditor;

namespace HFK.ObjectEditor.WPF.SampleApp.Classes
{
    public class EditorAnnotation
    {
        public int DefaultEditor
        {
            get;
            set;
        }

        [EditorResourceKey( Key = "upDownIntegerEditorTemplate")]
        public int CustomEditor
        {
            get;
            set;
        }

    }
}
