using MiniCRM.Domain.Models;
using System;

namespace MiniCRM.Domain.Events
{
    public class DepartmentEventArgs : EventArgs
    {
        public DepartmentEventArgs(Department department)
        {
            Department = department ?? throw new ArgumentNullException(nameof(department));
        }

        public Department Department { get; private set; }
    }
}
