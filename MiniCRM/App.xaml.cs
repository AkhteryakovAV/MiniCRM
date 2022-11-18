using MiniCRM.Domain;
using MiniCRM.Domain.Models;
using MiniCRM.EFDataAccess;
using MiniCRM.PresentationLogic;
using MiniCRM.PresentationLogic.ViewModels;
using MiniCRM.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SplashScreen = MiniCRM.Views.SplashScreen;

namespace MiniCRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INavigationService
    {
        private readonly SplashScreen splashScreen;
        private readonly MainContext context;

        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Department> departmentRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Tag> tagRepository;

        private readonly INavigationService navigationService;

        public App()
        {
            splashScreen = new SplashScreen();
            splashScreen.Show();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MainContext mainContext = new MainContext(connectionString);

            IRepository<Employee> employeeRepository = new EFRepository<Employee>(mainContext);
            IRepository<Department> departmentRepository = new EFRepository<Department>(mainContext);
            IRepository<Order> orderRepository = new EFRepository<Order>(mainContext);
            IRepository<Tag> tagRepository = new EFRepository<Tag>(mainContext);

            navigationService = this;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShowWindow<MainViewModel>(false);
            splashScreen.Close();
        }

        public void ShowWindow<TViewModel>(bool showDialog = true, object parametr = null) where TViewModel : BaseViewModel
        {
            Window window = CreateWindow(typeof(TViewModel), parametr);
            if (showDialog)
                window?.ShowDialog();
            else
                window?.Show();
        }

        private Window CreateWindow(Type viewModelType, object parametr)
        {
            if (viewModelType == typeof(MainViewModel))
            {
                return new MainView(
                    new MainViewModel(
                        navigationService, 
                        employeeRepository, 
                        departmentRepository,
                        orderRepository, 
                        tagRepository));
            }
            else if (viewModelType == typeof(DepartmentsViewModel))
            {
                return new DepartmentsView(new DepartmentsViewModel());
            }
            else if (viewModelType == typeof(EmployeesViewModel))
            {
                return new EmployeesView(new EmployeesViewModel());
            }

            return null;
        }

    }
}
