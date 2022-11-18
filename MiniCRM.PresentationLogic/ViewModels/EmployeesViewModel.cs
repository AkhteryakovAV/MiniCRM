using MiniCRM.Domain;
using MiniCRM.Domain.Collections;
using MiniCRM.Domain.Events;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.PresentationLogic.ViewModels
{
    public sealed class EmployeesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IRepository<Employee> _employeeRepository;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _createEmployeeCommand;

        public EmployeesViewModel(INavigationService navigationService,
                                  IRepository<Employee> employeeRepository)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

            Employees = new NotifyCollection<Employee>(_employeeRepository.GetAll());
        }

        public NotifyCollection<Employee> Employees { get; set; }

        public RelayCommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(parametr =>
        {
            if (parametr is Employee)
                _navigationService.ShowWindow<CreateEditEmployeeViewModel>(parametr: parametr);
        }));

        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(parametr =>
        {
            if (parametr is Employee employee)
            {
                _employeeRepository.Delete(employee.Id);
                Employees.Remove(employee);
            }
        }));

        public RelayCommand CreateEmployeeCommand => _createEmployeeCommand ?? (_createEmployeeCommand = new RelayCommand(parametr =>
        {
            _navigationService.ShowWindow<CreateEditEmployeeViewModel>();
        }));

        public void EmployeeAdded(object sender, EmployeeEventArgs e)
        {
            Employees.Add(e.Employee);
        }

    }
}
