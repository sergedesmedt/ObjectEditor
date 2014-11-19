using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HFK.ObjectEditor.WPF
{
    public class ObjectEditorItem : ContentControl
    {
        static ObjectEditorItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ObjectEditorItem), new FrameworkPropertyMetadata(typeof(ObjectEditorItem)));
        }
    }
}
