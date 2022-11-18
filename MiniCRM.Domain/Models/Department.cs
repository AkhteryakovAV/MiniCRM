using System;
using System.Collections.Generic;

namespace MiniCRM.Domain.Models
{
    public class Department : NotifyPropertyObject, IEquatable<Department>
    {
        private string name;
        private Guid? chiefId;
        private Employee chief;

        public Guid Id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public Guid? ChiefId
        {
            get => chiefId;
            set
            {
                chiefId = value;
                OnPropertyChanged(nameof(Chief));
            }
        }
        public Employee Chief
        {
            get => chief;
            set
            {
                chief = value;
                OnPropertyChanged();
            }
        }
        public List<Employee> Staff { get; set; }

        public bool Equals(Department other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals((Department)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
