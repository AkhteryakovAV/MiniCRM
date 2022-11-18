using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : Window
    {
        public NewOrderView(NewOrderViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
