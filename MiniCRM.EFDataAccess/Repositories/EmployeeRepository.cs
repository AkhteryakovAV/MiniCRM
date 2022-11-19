using MiniCRM.Domain.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MiniCRM.EFDataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(MainContext context) : base(context)
        { }

        public override Employee[] GetAll()
        {
            return _context.Employees.Include(e => e.Department)
                                     .ToArray();
        }

        public override Employee GetById(Guid id)
        {
            return _context.Employees.Include(e => e.Department)
                                     .FirstOrDefault(e => e.Id == id);
        }

    }
}
