using MiniCRM.Domain;
using MiniCRM.Domain.Collections;
using MiniCRM.Domain.Events;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniCRM.PresentationLogic.ViewModels
{
    public sealed class EmployeesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IDialogService _dialogService;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _createEmployeeCommand;
        
        public EmployeesViewModel(INavigationService navigationService,
                                  IRepository<Employee> employeeRepository,
                                  IDialogService dialogService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

            Employees = new NotifyCollection<Employee>(_employeeRepository.GetAll().OrderBy(e=>e.Surname));
        }

        public event EventHandler<EmployeeEventArgs> EmployeeDeleted;

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
                if (_dialogService.ShowMessageQuestion("Удалить сотрудника? Также будут удалены заказы, выполненные этим сотрудником.") == MessageBoxResult.Yes)
                {
                    _employeeRepository.Delete(employee.Id);
                    Employees.Remove(employee);
                    EmployeeDeleted?.Invoke(this, new EmployeeEventArgs(employee));
                }
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
