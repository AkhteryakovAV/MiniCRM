using System;
using System.Collections.Generic;

namespace MiniCRM.Domain.Models
{
    public class Tag : NotifyPropertyObject, IEquatable<Tag>
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

        public bool Equals(Tag other)
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
