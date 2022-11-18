using MiniCRM.Domain.Enums;
using System;

namespace MiniCRM.Domain.Models
{
    public class Employee : NotifyPropertyObject, IEquatable<Employee>
    {
        private string surname;
        private string name;
        private string middleName;
        private DateTime? birthday;
        private Gender gender;
        private Guid? departmentId;
        private Department department;

        public Guid Id { get; set; }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birthday
        {
            get => birthday;
            set
            {
                birthday = value;
                OnPropertyChanged();
            }
        }
        public Gender Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }
        public Guid? DepartmentId
        {
            get => departmentId;
            set
            {
                departmentId = value;
                OnPropertyChanged(nameof(Department));
            }
        }
        public Department Department
        {
            get => department;
            set
            {
                department = value;
                OnPropertyChanged();
            }
        }

        public bool Equals(Employee other)
        {
            return Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals((Employee)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
