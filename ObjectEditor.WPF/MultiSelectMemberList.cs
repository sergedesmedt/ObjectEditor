using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF
{
    public class SelectedValueList : EventArgs
    {
        public List<string> Values
        {
            get;
            set;
        }
    }

    public class MultiSelectMemberList : ObservableCollection<SelectMember>
    {
        public event EventHandler<SelectedValueList> SelectedValuesChanged;

        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (object item in e.NewItems)
                {
                    if (!(item is SelectMember))
                    {
                        throw new Exception();
                    }

                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(EnumMemberList_PropertyChanged);
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (object item in e.NewItems)
                {
                    if (!(item is SelectMember))
                    {
                        throw new Exception();
                    }

                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(EnumMemberList_PropertyChanged);
                }
            }
            base.OnCollectionChanged(e);
        }

        void EnumMemberList_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            List<String> selectedValues = new List<string>(Items.Where(x => x.IsSelected == true).Select(x => x.Value).AsEnumerable());

            if (SelectedValuesChanged != null)
            {
                SelectedValuesChanged(this, new SelectedValueList() { Values = selectedValues });
            }
        }
    }
}
