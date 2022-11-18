using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for CreateEditDepartmentView.xaml
    /// </summary>
    public partial class CreateEditDepartmentView : Window
    {
        public CreateEditDepartmentView(CreateEditDepartmentViewModel viewModel)
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
