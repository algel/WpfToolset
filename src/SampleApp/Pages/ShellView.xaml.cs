using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
}
