using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SimpleProperties.xaml
    /// </summary>
    public partial class SimpleProperties : UserControl
    {
        public SimpleProperties()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectToEdit = new Classes.SimpleProperties();

            objectToEdit.StringProperty = "ValueOne";
            objectToEdit.IntegerProperty = 1;
            objectToEdit.EnumProperty = Classes.CustomEnum.EnumValue2;
            objectToEdit.FlagProperty = Classes.CustomFlag.FlagValue1 | Classes.CustomFlag.FlagValue3;

            MyObjectEditor.ObjectToEdit = objectToEdit;
        }

        private void showProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(objectToEdit.StringProperty, "StringProperty");
            MessageBox.Show(objectToEdit.IntegerProperty.ToString(), "IntegerProperty");
            MessageBox.Show(objectToEdit.BooleanProperty.ToString(), "BooleanProperty");
            MessageBox.Show(objectToEdit.EnumProperty.ToString(), "EnumProperty");
            MessageBox.Show(objectToEdit.FlagProperty.ToString(), "FlagProperty");
        }

        Classes.SimpleProperties objectToEdit;
    }
}
