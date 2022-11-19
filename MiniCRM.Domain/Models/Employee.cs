using MiniCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public Employee()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; set; }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AbbreviatedName));
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AbbreviatedName));
            }
        }
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AbbreviatedName));
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
        [NotMapped]
        public string AbbreviatedName
        {
            get
            {
                string result = string.Empty;
                if (!string.IsNullOrEmpty(Surname))
                {
                    result += Surname;
                    if (!string.IsNullOrEmpty(Name))
                    {
                        result += " " + Name.First() + ".";

                        if (!string.IsNullOrEmpty(MiddleName))
                        {
                            result += MiddleName.First() + ".";
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(Name))
                {
                    result += Name;

                    if (!string.IsNullOrEmpty(Name))
                    {
                        result += " " + Name.First() + ".";
                    }
                }
                else
                {
                    result += Name;
                }
                return result;
            }
        }
        public List<Order> Orders { get; set; }


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
