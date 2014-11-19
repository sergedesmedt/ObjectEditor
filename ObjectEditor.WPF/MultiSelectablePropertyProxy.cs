using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HFK.ObjectEditor.WPF
{
    public class MultiSelectablePropertyProxy : PropertyProxy
    {
        public MultiSelectablePropertyProxy(PropertyDescriptor propertyDescriptor, object objectToEdit)
            : base(propertyDescriptor, objectToEdit)
        {
            HasAllowedValues = true;

            valueList = new MultiSelectMemberList();

            foreach (object field in Enum.GetValues(propertyDescriptor.PropertyType))
            {
                SelectMember member = new SelectMember() { Value = field.ToString() };
                if (propertyDescriptor.GetValue(objectToEdit).ToString().Contains(field.ToString()))
                {
                    member.IsSelected = true;
                }
                valueList.Add(member);
            }

            valueList.SelectedValuesChanged += new EventHandler<SelectedValueList>(valueList_SelectedValueChanged);
        }

        public MultiSelectMemberList ValueList
        {
            get
            {
                return valueList;
            }
            //set
            //{
            //}
        }

        void valueList_SelectedValueChanged(object sender, SelectedValueList e)
        {
            string valueList = "";
            if (e.Values.Count == 0)
            {
                Property.SetValue(ObjectToEdit, 0);
                return;
            }

            foreach (string value in e.Values)
            {
                valueList = valueList + "," + value;
            }
            Property.SetValue(ObjectToEdit, Enum.Parse(Property.PropertyType, valueList.Substring(1)));
        }

        MultiSelectMemberList valueList;
    }
}
