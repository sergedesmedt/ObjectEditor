using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HFK.ObjectEditor.WPF
{
    public class ObjectEditor : ItemsControl
    {
        static ObjectEditor()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(ObjectEditor), new FrameworkPropertyMetadata(typeof(ObjectEditor)));
        }

        public ObjectEditor()
        {
            ItemTemplateSelector = new TypeEditorDataTemplateSelector();
        }

        public object ObjectToEdit
        {
            get { return objectToEdit; }
            set
            {
                objectToEdit = value;
                if (ShowCategories)
                {
                    ICollectionView properties = CollectionViewSource.GetDefaultView(ObjectProxy.GetProperties(objectToEdit));
                    properties.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                    ItemsSource = properties;
                }
                else
                {
                    ItemsSource = ObjectProxy.GetProperties(objectToEdit);
                }
            }
        }

        public bool ShowCategories
        {
            get
            {
                return showCategories;
            }
            set
            {
                showCategories = value;
                if (showCategories)
                {
                    ICollectionView properties = CollectionViewSource.GetDefaultView(ObjectProxy.GetProperties(objectToEdit));
                    properties.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                    ItemsSource = properties;
                }
                else
                {
                    ItemsSource = ObjectProxy.GetProperties(objectToEdit);
                }
            }
        }

        public TypeEditorRegistry EditorRegistry
        {
            get
            {
                if (ItemTemplateSelector is TypeEditorDataTemplateSelector)
                    return (ItemTemplateSelector as TypeEditorDataTemplateSelector).EditorRegistry;

                return null;
            }
            set
            {
                if (ItemTemplateSelector is TypeEditorDataTemplateSelector)
                    (ItemTemplateSelector as TypeEditorDataTemplateSelector).EditorRegistry = value;
            }
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ObjectEditorItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ObjectEditorItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }

        object objectToEdit;
        bool showCategories;
    }
}
