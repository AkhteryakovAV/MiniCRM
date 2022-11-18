using MiniCRM.Domain;
using MiniCRM.Domain.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MiniCRM.EFDataAccess.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly MainContext _context;

        public EmployeeRepository(MainContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Employee entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!_context.Employees.Any(e => e.Id == entity.Id))
            {
                _ = _context.Employees.Add(entity);
                _ = _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            _ = _context.Employees.Remove(GetById(id));
            _ = _context.SaveChanges();
        }

        public Employee[] GetAll()
        {
            return _context.Employees.Include(e => e.Department)
                                     .ToArray();
        }

        public Employee GetById(Guid id)
        {
            return _context.Employees.Include(e => e.Department)
                                     .FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }
    }
}
