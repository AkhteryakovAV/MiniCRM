using MiniCRM.Domain;
using MiniCRM.Domain.Enums;
using MiniCRM.Domain.Events;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.PresentationLogic.ViewModels
{
    public class CreateEditEmployeeViewModel : BaseViewModel
    {
        private IRepository<Employee> _employeeRepository;
        private Employee _employee;
        private RelayCommand _saveEmployeeCommand;
        private bool _editMode;
        public CreateEditEmployeeViewModel(IRepository<Employee> employeeRepository, Employee employee)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            if (employee == null)
                _employee = new Employee() { Id = Guid.NewGuid() };
            else
            {
                _employee = employee;
                _editMode = true;
            }
        }

        public event EventHandler<EmployeeEventArgs> EmployeeAdded;

        public string Surname
        {
            get => _employee.Surname;
            set
            {
                _employee.Surname = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _employee.Name;
            set
            {
                _employee.Name = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => _employee.MiddleName;
            set
            {
                _employee.MiddleName = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Birthday
        {
            get => _employee.Birthday;
            set
            {
                _employee.Birthday = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => _employee.Gender;
            set
            {
                _employee.Gender = value;
                OnPropertyChanged();
            }
        }

        public Department Department
        {
            get => _employee.Department;
            set
            {
                _employee.Department = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveEmployeeCommand => _saveEmployeeCommand ?? (_saveEmployeeCommand = new RelayCommand(args =>
        {
            if (_editMode)
            {
                _employeeRepository.Update(_employee);
            }
            else
            {
                _employeeRepository.Add(_employee);
                EmployeeAdded?.Invoke(this, new EmployeeEventArgs(_employee));
            }
        }));

    }
}
