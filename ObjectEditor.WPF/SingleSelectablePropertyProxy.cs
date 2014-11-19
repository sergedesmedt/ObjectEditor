using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using HFK.ObjectEditor.WPF.DataAnnotations;

namespace HFK.ObjectEditor.WPF
{
    public class SingleSelectablePropertyProxy : PropertyProxy
    {
        public SingleSelectablePropertyProxy(PropertyDescriptor propertyDescriptor, object objectToEdit)
            : base(propertyDescriptor, objectToEdit)
        {
            HasAllowedValues = true;

            valueList = new SingleSelectMemberList();

            if (propertyDescriptor.PropertyType.IsEnum)
            {
                foreach (FieldInfo field in propertyDescriptor.PropertyType.GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    SelectMember member = new SelectMember() { Value = field.Name, Display = field.Name };
                    object[] displayAttributes = field.GetCustomAttributes(typeof(DisplayAttribute), false);
                    if(displayAttributes.Count() != 0)
                    {
                        DisplayAttribute displayAttribute = displayAttributes[0] as DisplayAttribute;
                        member.Display = displayAttribute.Name;
                    }
                    if (propertyDescriptor.GetValue(ObjectToEdit).ToString() == field.Name)
                    {
                        member.IsSelected = true;
                    }
                    valueList.Add(member);
                }
            }
            else
            {
                foreach (AllowedStringValue allowedValue in propertyDescriptor.Attributes.OfType<AllowedStringValue>())
                {
                    SelectMember member = new SelectMember() { Value = allowedValue.Value, Display = allowedValue.DisplayValue };
                    if(String.IsNullOrEmpty(member.Display))
                    {
                        member.Display = member.Value;
                    }
                    if (propertyDescriptor.GetValue(ObjectToEdit).ToString() == member.Value)
                    {
                        member.IsSelected = true;
                    }
                    valueList.Add(member);
                }
            }

            valueList.SelectedValueChanged += new EventHandler<SelectedValue>(valueList_SelectedValueChanged);
        }

        public SingleSelectMemberList ValueList
        {
            get
            {
                return valueList;
            }
            //set
            //{
            //}
        }

        private void valueList_SelectedValueChanged(object sender, SelectedValue e)
        {
            Property.SetValue(ObjectToEdit, Enum.Parse(Property.PropertyType, e.Value));
        }

        private SingleSelectMemberList valueList;
    }
}
