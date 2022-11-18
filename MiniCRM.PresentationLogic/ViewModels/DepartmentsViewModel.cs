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
    public sealed class DepartmentsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IDialogService _dialogService;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _createDepartmentCommand;

        public DepartmentsViewModel(INavigationService navigationService,
                                    IRepository<Department> departmentRepository,
                                    IDialogService dialogService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

            Departments = new NotifyCollection<Department>(_departmentRepository.GetAll());
        }

        public NotifyCollection<Department> Departments { get; set; }

        public RelayCommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(parametr =>
        {
            if (parametr is Department)
                _navigationService.ShowWindow<CreateEditDepartmentViewModel>(parametr: parametr);
        }));

        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(parametr =>
        {
            if (parametr is Department department)
            {
                if (_dialogService.ShowMessageQuestion("Удалить подразделение?") == MessageBoxResult.Yes)
                {
                    _departmentRepository.Delete(department.Id);
                    Departments.Remove(department);
                }
            }
        }));

        public RelayCommand CreateDepartmentCommand => _createDepartmentCommand ?? (_createDepartmentCommand = new RelayCommand(parametr =>
        {
            _navigationService.ShowWindow<CreateEditDepartmentViewModel>();
        }));

        public void DepartmentAdded(object sender, DepartmentEventArgs e)
        {
            Departments.Add(e.Department);
        }
    }
}
