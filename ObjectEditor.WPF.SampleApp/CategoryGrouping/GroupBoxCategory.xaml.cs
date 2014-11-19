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

namespace HFK.ObjectEditor.WPF.SampleApp.CategoryGrouping
{
    /// <summary>
    /// Interaction logic for GroupBoxCategory.xaml
    /// </summary>
    public partial class GroupBoxCategory : UserControl
    {
        public GroupBoxCategory()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectToEdit = new Classes.CategorizedProperties();

            objectToEdit.StringProperty1 = "ValueOne";
            objectToEdit.IntegerProperty2 = 2;
            objectToEdit.StringProperty3 = "ValueThree";
            objectToEdit.IntegerProperty4 = 4;

            MyObjectEditor.ShowCategories = true;
            MyObjectEditor.ObjectToEdit = objectToEdit;
        }

        private void showProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(objectToEdit.StringProperty1, "StringProperty1");
            MessageBox.Show(objectToEdit.IntegerProperty2.ToString(), "IntegerProperty2");
            MessageBox.Show(objectToEdit.StringProperty3, "StringProperty3");
            MessageBox.Show(objectToEdit.IntegerProperty4.ToString(), "IntegerProperty4");
        }

        Classes.CategorizedProperties objectToEdit;
    }
}
