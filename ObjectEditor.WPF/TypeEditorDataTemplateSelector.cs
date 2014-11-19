using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HFK.ObjectEditor.WPF
{
    public class TypeEditorDataTemplateSelector : DataTemplateSelector
    {
        public TypeEditorRegistry EditorRegistry
        {
            get;
            set;
        }

        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is PropertyProxy)
            {
                PropertyProxy propertyProxy = item as PropertyProxy;

                String editorResoucreKey = propertyProxy.EditorResourceKey;
                if (editorResoucreKey != null)
                {
                    DataTemplate dataTemplate = Application.Current.FindResource(editorResoucreKey) as DataTemplate;
                    return dataTemplate;
                }

                if (EditorRegistry != null && EditorRegistry.ContainsKey(propertyProxy.DataType))
                {
                    return EditorRegistry[propertyProxy.DataType];
                }

                if (propertyProxy.DataType == typeof(int) && !propertyProxy.HasAllowedValues)
                {
                    ComponentResourceKey integerKey = new ComponentResourceKey(typeof(ObjectEditor), "integerEditorTemplate");
                    return element.FindResource(integerKey) as DataTemplate;
                }
                else if (propertyProxy.DataType == typeof(string) && !propertyProxy.HasAllowedValues)
                {
                    ComponentResourceKey stringKey = new ComponentResourceKey(typeof(ObjectEditor), "defaultEditorTemplate");
                    return element.FindResource(stringKey) as DataTemplate;
                }
                else if(propertyProxy.DataType == typeof(bool) && !propertyProxy.HasAllowedValues)
                {
                    ComponentResourceKey stringKey = new ComponentResourceKey(typeof(ObjectEditor), "boolEditorTemplate");
                    return element.FindResource(stringKey) as DataTemplate;
                }
                else if (propertyProxy.DataType.IsEnum)
                {
                    if (propertyProxy.DataType.GetCustomAttributes(typeof(FlagsAttribute), true).Count() == 0)
                    {
                        ComponentResourceKey stringKey = new ComponentResourceKey(typeof(ObjectEditor), "singleSelectEditorTemplate");
                        return element.FindResource(stringKey) as DataTemplate;
                    }
                    else
                    {
                        ComponentResourceKey stringKey = new ComponentResourceKey(typeof(ObjectEditor), "multiSelectEditorTemplate");
                        return element.FindResource(stringKey) as DataTemplate;
                    }
                }
                else if (propertyProxy.HasAllowedValues)
                {
                    ComponentResourceKey stringKey = new ComponentResourceKey(typeof(ObjectEditor), "singleSelectEditorTemplate");
                    return element.FindResource(stringKey) as DataTemplate;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }

            return null;
        }
    }
}
