using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace SampleApp.Pages
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView
    {
        public ShellView()
        {
            InitializeComponent();

        }

        private void BtnApplyColumnDefinitions_OnClick(object sender, RoutedEventArgs e)
        {
            BindingOperations.GetBindingExpression(tbColumnDefinitions, TextBox.TextProperty)?.UpdateSource();
        }

        private void ButtonAddLabel_OnClick(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new Label { Content = "New label" });
        }

        private void ButtonAddTextBox_OnClick(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(new TextBox());
        }

        private void ButtonRemoveLast_OnClick(object sender, RoutedEventArgs e)
        {
            var last = grid.Children.Cast<UIElement>().LastOrDefault();
            if (last != null)
                grid.Children.Remove(last);
        }
    }

    [ContentProperty(nameof(Children))]
    public class RowItem : Control
    {
        private List<UIElement> _children;
        public List<UIElement> Children => _children??(_children=new List<UIElement>());

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(nameof(Number), typeof(string), typeof(RowItem), new PropertyMetadata(default(string)));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            var itemsHost = GetTemplateChild("PART_ItemsHost") as Panel;
            if (itemsHost != null)
            {
                foreach (var child in Children)
                {
                    itemsHost.Children.Add(child);
                }
            }
            base.OnApplyTemplate();
        }
    }
}
