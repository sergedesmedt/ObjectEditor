using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using HFK.ObjectEditor.WPF.DataAnnotations;

namespace HFK.ObjectEditor.WPF
{
    /// <summary>
    /// Base class for all property editors
    /// </summary>
    public class PropertyProxy
    {
        public PropertyProxy(PropertyDescriptor propertyDescriptor, object objectToEdit)
        {
            Property = propertyDescriptor;
            ObjectToEdit = objectToEdit;
            HasAllowedValues = false;
            Converter = propertyDescriptor.Converter;
        }

        public Type DataType
        {
            get
            {
                return Property.PropertyType;
            }
        }

        public string Name
        {
            get
            {
                return Property.Name;
            }
        }

        public string DisplayName
        {
            get
            {
                return Property.DisplayName;
            }
        }

        public string Description
        {
            get
            {
                return string.IsNullOrEmpty(Property.Description) ? DisplayName : Property.Description;
            }
        }

        public string Category
        {
            get
            {
                return Property.Category;
            }
        }

        public bool HasAllowedValues
        {
            get;
            protected set;
        }

        public TypeConverter Converter 
        { 
            get; 
            set; 
        }
        
        protected PropertyDescriptor Property 
        { 
            get; 
            private set; 
        }

        protected object ObjectToEdit 
        { 
            get; 
            private set; 
        }

        public String EditorResourceKey
        {
            get
            {
                EditorResourceKey edtiorAttribute = Property.Attributes.OfType<EditorResourceKey>().FirstOrDefault();
                if (edtiorAttribute == null)
                {
                    return null;
                }
                return edtiorAttribute.Key;
            }
        }
    }
}
