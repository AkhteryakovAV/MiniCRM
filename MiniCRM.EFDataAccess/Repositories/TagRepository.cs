using MiniCRM.Domain.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace MiniCRM.EFDataAccess.Repositories
{
    public class TagRepository : BaseRepository<Tag>
    {
        public TagRepository(MainContext context) : base(context)
        {
        }

        public override Tag[] GetAll()
        {
            return _context.Tags.Include(t => t.Orders)
                                .ToArray();
        }

        public override Tag GetById(Guid id)
        {
            return _context.Tags.Include(t => t.Orders)
                                .FirstOrDefault(e => e.Id == id);
        }
    }
}
