using MiniCRM.Domain;
using System;
using System.Data.Entity;

namespace MiniCRM.EFDataAccess.Repositories
{
    public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : NotifyPropertyObject
    {
        protected readonly MainContext _context;
        private readonly DbSet<TModel> entities;

        public BaseRepository(MainContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            entities = context.Set<TModel>();
        }

        public virtual void Add(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (_context.IsNew(entity))
                _ = entities.Add(entity);
            _ = _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            TModel entity = GetById(id);
            if (entity != null)
            {
                _ = entities.Remove(entity);
                _ = _context.SaveChanges();
            }
        }

        public abstract TModel[] GetAll();

        public abstract TModel GetById(Guid id);

        public void Update(TModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _ = _context.SaveChanges();
        }
    }
}
