using System;
using System.Collections.Generic;

namespace MiniCRM.Domain.Models
{
    public class Order : NotifyPropertyObject, IEquatable<Order>
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

        public bool Equals(Order other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals((Tag)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
