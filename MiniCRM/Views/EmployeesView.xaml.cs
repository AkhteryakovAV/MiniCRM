using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : Window
    {
        public EmployeesView(EmployeesViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
