using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for CreateEditEmployeeView.xaml
    /// </summary>
    public partial class CreateEditEmployeeView : Window
    {
        public CreateEditEmployeeView(CreateEditEmployeeViewModel viewModel)
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
