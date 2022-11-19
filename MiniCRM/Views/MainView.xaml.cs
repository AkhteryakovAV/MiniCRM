using MiniCRM.PresentationLogic.ViewModels;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

    }
}
