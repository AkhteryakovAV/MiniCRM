using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for CreateEditOrderView.xaml
    /// </summary>
    public partial class CreateEditOrderView : Window
    {
        public CreateEditOrderView(CreateEditOrderViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
