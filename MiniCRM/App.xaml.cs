using MiniCRM.Domain;
using MiniCRM.Domain.Events;
using MiniCRM.Domain.Models;
using MiniCRM.EFDataAccess;
using MiniCRM.EFDataAccess.Repositories;
using MiniCRM.PresentationLogic;
using MiniCRM.PresentationLogic.ViewModels;
using MiniCRM.Services;
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
        private readonly MainContext mainContext;

        private readonly IRepository<Employee> employeeRepository;
        private readonly IRepository<Department> departmentRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Tag> tagRepository;

        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public event EventHandler<EmployeeEventArgs> EmployeeAdded;
        public event EventHandler<DepartmentEventArgs> DepartmentAdded;

        public App()
        {
            splashScreen = new SplashScreen();
            splashScreen.Show();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            mainContext = new MainContext(connectionString);

            employeeRepository = new EmployeeRepository(mainContext);
            departmentRepository = new DepartmentRepository(mainContext);
            orderRepository = new EFRepository<Order>(mainContext);
            tagRepository = new EFRepository<Tag>(mainContext);

            navigationService = this;
            dialogService = new DialogService();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mainContext.Dispose();
            base.OnExit(e);
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
                DepartmentsViewModel departmentsViewModel = new DepartmentsViewModel(navigationService,
                                                                                     departmentRepository,
                                                                                     dialogService);
                DepartmentAdded += departmentsViewModel.DepartmentAdded;
                return new DepartmentsView(departmentsViewModel);
            }
            else if (viewModelType == typeof(CreateEditDepartmentViewModel))
            {
                Department department = null;
                if (parametr is Department)
                    department = (Department)parametr;

                CreateEditDepartmentViewModel createEditDepartmentViewModel = new CreateEditDepartmentViewModel(departmentRepository, department);
                createEditDepartmentViewModel.DepartmentAdded += OnDepartmentAdded;
                return new CreateEditDepartmentView(createEditDepartmentViewModel);
            }
            else if (viewModelType == typeof(EmployeesViewModel))
            {
                EmployeesViewModel employeesViewModel = new EmployeesViewModel(navigationService,
                                                                               employeeRepository,
                                                                               dialogService);
                EmployeeAdded += employeesViewModel.EmployeeAdded;
                return new EmployeesView(employeesViewModel);
            }
            else if (viewModelType == typeof(CreateEditEmployeeViewModel))
            {
                Employee employee = null;
                if (parametr is Employee)
                    employee = (Employee)parametr;

                CreateEditEmployeeViewModel createEditEmployeeViewModel = new CreateEditEmployeeViewModel(employeeRepository, employee);
                createEditEmployeeViewModel.EmployeeAdded += OnEmployeeAdded;
                return new CreateEditEmployeeView(createEditEmployeeViewModel);
            }
            else if (viewModelType == typeof(NewOrderViewModel))
            {
                return new NewOrderView(new NewOrderViewModel());
            }
            return null;
        }

        private void OnDepartmentAdded(object sender, DepartmentEventArgs e)
        {
            DepartmentAdded?.Invoke(sender, e);
        }

        private void OnEmployeeAdded(object sender, EmployeeEventArgs e)
        {
            EmployeeAdded?.Invoke(sender, e);
        }
    }
}
