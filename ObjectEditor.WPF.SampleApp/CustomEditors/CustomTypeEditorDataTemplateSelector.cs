using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HFK.ObjectEditor.WPF.SampleApp.CustomEditors
{
    public class CustomTypeEditorDataTemplateSelector : TypeEditorDataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is PropertyProxy)
            {
                PropertyProxy propertyDescriptor = item as PropertyProxy;

                if (propertyDescriptor.DataType == typeof(int))
                {
                    //ComponentResourceKey integerKey = new ComponentResourceKey(typeof(DummyClass), "upDownIntegerEditorTemplate");
                    DataTemplate dataTemplate = Application.Current.FindResource("upDownIntegerEditorTemplate") as DataTemplate;

                    return dataTemplate;
                }
                else
                {
                    return base.SelectTemplate(item, container);
                }
            }

            return null;
        }
    }
}
