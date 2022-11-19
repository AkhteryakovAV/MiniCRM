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
    public sealed class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Tag> _tagRepository;

        private RelayCommand _showEmployeesCommand;
        private RelayCommand _showDepartmentsCommand;
        private RelayCommand _createOrderCommand;
        private RelayCommand _editCommand;
        private RelayCommand _deleteCommand;

        public MainViewModel(INavigationService navigationService,
                             IDialogService dialogService,
                             IRepository<Employee> employeeRepository,
                             IRepository<Department> departmentRepository,
                             IRepository<Order> orderRepository,
                             IRepository<Tag> tagRepository)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));

            UpdateOrders();
            Tags = new NotifyCollection<Tag>(_tagRepository.GetAll());
        }

        private void UpdateOrders()
        {
            Orders = new NotifyCollection<Order>(_orderRepository.GetAll().OrderBy(o => o.Product));
            OnPropertyChanged(nameof(Orders));
        }

        public NotifyCollection<Order> Orders { get; set; }
        public NotifyCollection<Tag> Tags { get; set; }

        public RelayCommand ShowEmployeesCommand => _showEmployeesCommand
            ?? (_showEmployeesCommand = new RelayCommand(obj => _navigationService.ShowWindow<EmployeesViewModel>()));
        public RelayCommand ShowDepartmentsCommand => _showDepartmentsCommand
            ?? (_showDepartmentsCommand = new RelayCommand(obj => _navigationService.ShowWindow<DepartmentsViewModel>()));
        public RelayCommand CreateOrderCommand => _createOrderCommand
            ?? (_createOrderCommand = new RelayCommand(obj =>
            {
                _navigationService.ShowWindow<CreateEditOrderViewModel>();
            }));

        public RelayCommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(parametr =>
        {
            if (parametr is Order)
                _navigationService.ShowWindow<CreateEditOrderViewModel>(parametr: parametr);
        }));

        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(parametr =>
        {
            if (parametr is Order order)
            {
                if (_dialogService.ShowMessageQuestion("Удалить заказ?") == MessageBoxResult.Yes)
                {
                    _orderRepository.Delete(order.Id);
                    Orders.Remove(order);
                }
            }
        }));

        public void EmployeeDeleted(object sender, EmployeeEventArgs e)
        {
            UpdateOrders();
        }

        public void OrderAdded(object sender, OrderEventArgs e)
        {
            Orders.Add(e.Order);
        }
    }
}
