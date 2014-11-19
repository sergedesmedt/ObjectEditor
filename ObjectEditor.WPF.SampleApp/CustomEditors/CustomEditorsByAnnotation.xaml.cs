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

namespace HFK.ObjectEditor.WPF.SampleApp.CustomEditors
{
    /// <summary>
    /// Interaction logic for CustomEditorsByAnnotation.xaml
    /// </summary>
    public partial class CustomEditorsByAnnotation : UserControl
    {
        public CustomEditorsByAnnotation()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectToEdit = new Classes.EditorAnnotation();

            objectToEdit.DefaultEditor = 1;
            objectToEdit.CustomEditor = 10;

            MyObjectEditor.ObjectToEdit = objectToEdit;
        }

        private void showProperties_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(objectToEdit.DefaultEditor.ToString(), "DefaultEditor");
            MessageBox.Show(objectToEdit.CustomEditor.ToString(), "CustomEditor");
        }

        Classes.EditorAnnotation objectToEdit;
    }
}
