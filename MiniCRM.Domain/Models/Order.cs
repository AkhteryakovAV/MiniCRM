using System;
using System.Collections.Generic;

namespace MiniCRM.Domain.Models
{
    public class Order : NotifyPropertyObject
    {
        private string product;
        private Guid employeeId;
        private Employee employee;

        public Order()
        {
            Tags = new List<Tag>();
        }

        public Guid Id { get; set; }
        public string Product
        {
            get => product; set
            {
                product = value;
                OnPropertyChanged();
            }
        }
        public Guid EmployeeId
        {
            get => employeeId; set
            {
                employeeId = value;
                OnPropertyChanged(nameof(Employee));
            }
        }
        public Employee Employee
        {
            get => employee; set
            {
                employee = value;
                OnPropertyChanged();
            }
        }
        public List<Tag> Tags { get; set; }

    }
}
