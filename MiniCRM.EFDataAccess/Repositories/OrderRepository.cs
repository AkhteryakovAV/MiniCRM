using MiniCRM.Domain.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MiniCRM.EFDataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(MainContext context) : base(context)
        {
        }

        public override Order[] GetAll()
        {
            return _context.Orders.Include(o => o.Employee)
                                  .Include(o => o.Tags)
                                  .ToArray();
        }

        public override Order GetById(Guid id)
        {
            return _context.Orders.Include(o => o.Employee)
                                  .Include(o => o.Tags)
                                  .FirstOrDefault(o => o.Id == id);
        }
    }
}
