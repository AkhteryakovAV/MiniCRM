using System.Threading;
using System.Windows;

namespace MiniCRM.Views
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private int millisecondsDelay = 100;

        public SplashScreen()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Thread.Sleep(millisecondsDelay);
        }

    }
}
