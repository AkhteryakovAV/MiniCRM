﻿using System;

namespace MiniCRM.Domain.Models
{
    public class Department : NotifyPropertyObject
    {
        private string name;
        private Guid chiefId;
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
        public Guid ChiefId
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
    }
}