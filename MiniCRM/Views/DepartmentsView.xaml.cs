using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for DepartmentsView.xaml
    /// </summary>
    public partial class DepartmentsView : Window
    {
        public DepartmentsView(DepartmentsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
