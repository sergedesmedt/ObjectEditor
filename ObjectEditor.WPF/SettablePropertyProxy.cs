using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HFK.ObjectEditor.WPF
{
    public class SettablePropertyProxy : PropertyProxy, IDataErrorInfo
    {
        public SettablePropertyProxy(PropertyDescriptor prprt, object bjcttdt)
            : base(prprt, bjcttdt)
        {
        }

        public object Value
        {
            get
            {

                if (Converter == null)
                {
                    throw new NotSupportedException();
                }

                return (string)Converter.ConvertTo(Property.GetValue(ObjectToEdit/*, null*/), typeof(string));
            }

            set
            {
                if (Converter == null)
                {
                    throw new NotSupportedException();
                }

                if (Property.PropertyType.IsAssignableFrom(value.GetType()))
                {
                    Property.SetValue(ObjectToEdit, value);
                    return;
                }

                Property.SetValue(ObjectToEdit, Converter.ConvertFrom(null, null, value)/*, null*/);
            }
        }

        #region IDataErrorInfo Members

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get 
            {
                var pi = Property;
                var value = pi.GetValue(ObjectToEdit/*, null*/);

                var context = new ValidationContext(ObjectToEdit, null, null) { MemberName = Property.Name};
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateProperty(value, context, validationResults))
                {
                    var sb = new StringBuilder();
                    foreach (var vr in validationResults)
                    {
                        sb.AppendLine(vr.ErrorMessage);
                    }
                    return sb.ToString().Trim();
                }
                return null;
            }
        }

        #endregion
    }
}
