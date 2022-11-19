using MiniCRM.Domain;
using MiniCRM.Domain.Collections;
using MiniCRM.Domain.Events;
using MiniCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.PresentationLogic.ViewModels
{
    public class CreateEditOrderViewModel : BaseViewModel
    {
        private IRepository<Order> _ordersRepository;
        private IRepository<Tag> _tagRepository;
        private readonly IDialogService _dialogService;
        private Order _order;
        private RelayCommand _saveOrderCommand;
        private bool _editMode;

        public CreateEditOrderViewModel(IRepository<Order> ordersRepository,
                                        IRepository<Tag> tagRepository,
                                        IRepository<Employee> employeeRepository,
                                        IDialogService dialogService,
                                        Order order)
        {
            if (employeeRepository is null)
            {
                throw new ArgumentNullException(nameof(employeeRepository));
            }

            _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

            if (order == null)
                _order = new Order() { Id = Guid.NewGuid() };
            else
            {
                _order = order;
                _editMode = true;
            }
            Employees = new NotifyCollection<Employee>(employeeRepository.GetAll());
            Tags = new NotifyCollection<TagComboBoxItem>(
                tagRepository.GetAll()
                             .Select(t => new TagComboBoxItem(t, t.Orders.Contains(order)))
                             .ToList());
            Tags.CollectionChanged += Tags_CollectionChanged;
        }

        private void Tags_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _order.Tags = Tags.Where(t => t.IsSelected)
                              .Select(t => t.Tag)
                              .ToList();
        }

        public event EventHandler<OrderEventArgs> OrderAdded;

        public NotifyCollection<Employee> Employees { get; set; }
        public NotifyCollection<TagComboBoxItem> Tags { get; set; }
        public string Product
        {
            get => _order.Product;
            set
            {
                _order.Product = value;
                OnPropertyChanged();
            }
        }
        public Employee Employee
        {
            get => _order.Employee;
            set
            {
                _order.Employee = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand SaveOrderCommand => _saveOrderCommand ?? (_saveOrderCommand = new RelayCommand(args =>
        {
            if (_order.Employee != null)
            {
                if (_editMode)
                    _ordersRepository.Update(_order);
                else
                {
                    _ordersRepository.Add(_order);
                    OrderAdded?.Invoke(this, new OrderEventArgs(_order));
                }
            }
            else
            {
                _dialogService.ShowMessageInformation("Укажите сотрудника");
            }
        }));

    }

    public class TagComboBoxItem : NotifyPropertyObject
    {
        private bool _isSelected;

        public TagComboBoxItem(Tag tag, bool isSelected = false)
        {
            Tag = tag ?? throw new ArgumentNullException(nameof(tag));
            _isSelected = isSelected;
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public Tag Tag { get; set; }

    }
}
