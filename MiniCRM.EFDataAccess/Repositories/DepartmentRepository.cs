using MiniCRM.Domain.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace MiniCRM.EFDataAccess.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(MainContext context) : base(context)
        { }

        public override Department[] GetAll()
        {
            return _context.Departments.Include(d => d.Chief)
                                       .Include(d => d.Staff)
                                       .ToArray();
        }

        public override Department GetById(Guid id)
        {
            return _context.Departments.Include(d => d.Chief)
                                       .Include(d => d.Staff)
                                       .FirstOrDefault(e => e.Id == id);
        }

    }
}
