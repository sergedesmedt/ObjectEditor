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
    /// Interaction logic for ValidateProperties.xaml
    /// </summary>
    public partial class ValidateProperties : UserControl
    {
        public ValidateProperties()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectToEdit = new Classes.ValidationAnnotations();

            objectToEdit.StringProperty = "ValueOne";
            objectToEdit.IntegerProperty = 1;

            MyObjectEditor.ObjectToEdit = objectToEdit;
        }

        private void showProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(objectToEdit.StringProperty, "StringProperty");
            MessageBox.Show(objectToEdit.IntegerProperty.ToString(), "IntegerProperty");
        }

        Classes.ValidationAnnotations objectToEdit;
    }
}
