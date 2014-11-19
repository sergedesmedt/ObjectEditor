using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HFK.ObjectEditor.WPF
{
    public class SelectedValue : EventArgs
    {
        public string Value
        {
            get;
            set;
        }
    }

    public class SingleSelectMemberList : ObservableCollection<SelectMember>
    {
        public event EventHandler<SelectedValue> SelectedValueChanged;

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

        bool isChangingSelected = false;
        void EnumMemberList_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (isChangingSelected)
                return;

            isChangingSelected = true;

            SelectMember previousSelection = null;
            foreach (SelectMember member in Items)
            {
                if (member.IsSelected && member != sender)
                    previousSelection = member;
            }

            previousSelection.IsSelected = false;

            if (SelectedValueChanged != null)
            {
                SelectedValueChanged(this, new SelectedValue() { Value = (sender as SelectMember).Value });
            }

            isChangingSelected = false;

        }
    }
}
