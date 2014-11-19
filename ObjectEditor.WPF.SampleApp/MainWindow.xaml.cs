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

namespace HFK.ObjectEditor.WPF.SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowControl(Control control, string title)
        {

            control.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            control.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;

            control.Width = double.NaN;
            control.Height = double.NaN;

            controlContainer.Children.Clear();
            controlContainer.Children.Add(control);
        }

        private void btnSimpleProperties_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new DefaultEditors.SimpleProperties(), "Object with simple properties");
        }

        private void btnValidateProperties_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new DefaultEditors.ValidateProperties(), "Object with validation annotations");
        }

        private void btnDisplayProperties_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new DefaultEditors.DisplayProperties(), "Object with display annotations");
        }

        private void btnAllowedValues_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new DefaultEditors.AllowedValueProperties(), "Object with limited allowed values");
        }

        private void btnCustomEditorByXaml_Click(object sender, RoutedEventArgs e)
        {
            //ShowControl(new CustomEditors.CustomProperties(), "Object with simple properties");
        }

        private void btnCustomEditorByCode_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new CustomEditors.CustomEditorsInCode(), "Object with simple properties");
        }

        private void btnCustomEditorByAnnotations_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new CustomEditors.CustomEditorsByAnnotation(), "Object with simple properties");
        }

        private void btnCustomHolderByXaml_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new CustomHolder.GroupBoxHolder(), "Object with custom holder");
        }

        private void btnGroupCategoryByXaml_Click(object sender, RoutedEventArgs e)
        {
            ShowControl(new CategoryGrouping.GroupBoxCategory(), "Object with category grouping");
        }
    }
}
