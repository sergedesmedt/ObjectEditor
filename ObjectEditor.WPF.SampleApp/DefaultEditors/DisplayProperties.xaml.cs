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

namespace HFK.ObjectEditor.WPF.SampleApp.DefaultEditors
{
    /// <summary>
    /// Interaction logic for DisplayProperties.xaml
    /// </summary>
    public partial class DisplayProperties : UserControl
    {
        public DisplayProperties()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectToEdit = new Classes.DisplayAnnotations();

            objectToEdit.StringProperty = "ValueOne";
            objectToEdit.IntegerProperty = 1;

            MyObjectEditor.ObjectToEdit = objectToEdit;
        }

        private void showProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(objectToEdit.HiddenProperty, "HiddenProperty");
            MessageBox.Show(objectToEdit.StringProperty, "StringProperty");
            MessageBox.Show(objectToEdit.DisplayEnumProperty.ToString(), "DisplayEnumProperty");
            MessageBox.Show(objectToEdit.IntegerProperty.ToString(), "IntegerProperty");
        }

        Classes.DisplayAnnotations objectToEdit;
    }
}
