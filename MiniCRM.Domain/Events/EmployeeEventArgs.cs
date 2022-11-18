using MiniCRM.Domain.Models;
using System;

namespace MiniCRM.Domain.Events
{
    public class EmployeeEventArgs : EventArgs
    {
        public EmployeeEventArgs(Employee employee)
        {
            Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public Employee Employee { get; private set; }
    }
}
