using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using HFK.ObjectEditor.WPF.DataAnnotations;

namespace HFK.ObjectEditor.WPF
{
    public class ObjectProxy
    {
        static ObjectProxy()
        {
        }

        public static ObservableCollection<PropertyProxy> GetProperties(object obj)
        {
            ObservableCollection<PropertyProxy> result = new ObservableCollection<PropertyProxy>();

            PropertyDescriptorCollection propColl = TypeDescriptor.GetProperties(obj);

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                if (!property.IsBrowsable)
                {
                    continue;
                }

                PropertyProxy editor = null;
                if (IsSingleSelectable(property))
                {
                    editor = new SingleSelectablePropertyProxy(property, obj);
                }
                else if (IsMultiSelectable(property))
                {
                    editor = new MultiSelectablePropertyProxy(property, obj);
                }
                else
                {
                    editor = new SettablePropertyProxy(property, obj);
                }

                result.Add(editor);
                foreach (TypeConverter converter in typeConverterList.Where(x => x.Key == editor.DataType).Select(x => x.Value))
                {
                    if (converter.CanConvertTo(typeof(string)))
                    {
                        editor.Converter = converter;
                        break;
                    }
                }
                 
            }

            return result;
        }

        private static bool IsSingleSelectable(PropertyDescriptor property)
        {
            if (property.PropertyType.IsEnum
                && property.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), true).Count() == 0)
                return true;
            if (property.Attributes.OfType<AllowedStringValue>().Any())
            {
                return true;
            }

            return false;
        }

        private static bool IsMultiSelectable(PropertyDescriptor property)
        {
            if (property.PropertyType.IsEnum
                && property.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), true).Count() != 0)
                return true;

            return false;
        }

        private static Dictionary<Type, TypeConverter> typeConverterList = new Dictionary<Type, TypeConverter>();

    }
}
