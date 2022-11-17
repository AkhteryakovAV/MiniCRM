using System;
using System.Collections.Generic;

namespace MiniCRM.Domain.Models
{
    public class Tag : NotifyPropertyObject
    {
        private string name;

        public Tag()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public List<Order> Orders { get; set; }

    }
}
