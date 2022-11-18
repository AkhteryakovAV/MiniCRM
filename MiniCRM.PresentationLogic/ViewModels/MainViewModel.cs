using MiniCRM.Domain;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.PresentationLogic.ViewModels
{
    public sealed class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Tag> _tagRepository;

        private RelayCommand _showEmployeesCommand;
        private RelayCommand _showDepartmentsCommand;

        public MainViewModel(INavigationService navigationService,
                             IRepository<Employee> employeeRepository,
                             IRepository<Department> departmentRepository,
                             IRepository<Order> orderRepository,
                             IRepository<Tag> tagRepository)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        public RelayCommand ShowEmployeesCommand => _showEmployeesCommand
            ?? (_showEmployeesCommand = new RelayCommand(obj => _navigationService.ShowWindow<EmployeesViewModel>()));
        public RelayCommand ShowDepartmentsCommand => _showDepartmentsCommand
               ?? (_showDepartmentsCommand = new RelayCommand(obj => _navigationService.ShowWindow<DepartmentsViewModel>()));
    }
}
