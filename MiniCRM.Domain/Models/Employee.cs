using MiniCRM.Domain.Enums;
using System;

namespace MiniCRM.Domain.Models
{
    public class Employee : NotifyPropertyObject
    {
        private string surname;
        private string name;
        private string middleName;
        private DateTime? birthday;
        private Gender gender;
        private Guid departmentId;
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
        public Guid DepartmentId
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

    }
}
