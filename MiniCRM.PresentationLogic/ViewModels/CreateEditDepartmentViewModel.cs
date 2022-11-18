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
    public sealed class CreateEditDepartmentViewModel : BaseViewModel
    {
        private IRepository<Department> _departmentRepository;
        private Department _department;
        private RelayCommand _saveDepartmentCommand;
        private bool _editMode;

        public CreateEditDepartmentViewModel(IRepository<Department> departmentRepository,
                                             IRepository<Employee> employeeRepository,
                                             Department department)
        {
            if (employeeRepository is null)
            {
                throw new ArgumentNullException(nameof(employeeRepository));
            }

            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            if (department == null)
                _department = new Department() { Id = Guid.NewGuid() };
            else
            {
                _department = department;
                _editMode = true;
            }
            Employees = new NotifyCollection<Employee>(employeeRepository.GetAll());
        }

        public NotifyCollection<Employee> Employees { get; set; }

        public event EventHandler<DepartmentEventArgs> DepartmentAdded;
        public string Name
        {
            get => _department.Name;
            set
            {
                _department.Name = value;
                OnPropertyChanged();
            }
        }

        public Employee Chief
        {
            get => _department.Chief;
            set
            {
                _department.Chief = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveDepartmentCommand => _saveDepartmentCommand ?? (_saveDepartmentCommand = new RelayCommand(args =>
        {
            if (_editMode)
            {
                _departmentRepository.Update(_department);
            }
            else
            {
                _departmentRepository.Add(_department);
                DepartmentAdded?.Invoke(this, new DepartmentEventArgs(_department));
            }
        }));

    }
}
