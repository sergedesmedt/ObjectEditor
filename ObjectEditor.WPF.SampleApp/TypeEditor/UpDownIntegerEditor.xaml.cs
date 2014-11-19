using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HFK.ObjectEditor.WPF.SampleApp.TypeEditor
{
    /// <summary>
    /// http://stackoverflow.com/questions/841293/where-is-the-wpf-numeric-updown-control
    /// </summary>
    public partial class UpDownIntegerEditor : UserControl
    {
        public UpDownIntegerEditor()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UpDownIntegerEditor), new PropertyMetadata(0, ValueChangedCallback));

        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpDownIntegerEditor upDownEditor = d as UpDownIntegerEditor;

            if (upDownEditor != null && e.NewValue is int)
            {
                upDownEditor.ShowValue((int)e.NewValue);
            }
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void ShowValue(int value)
        {
            ValueTextBox.Text = value.ToString();
        }

        private void ValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            if (int.TryParse(ValueTextBox.Text, out result))
            {
                Value = result;
            }
        }
    }
}
