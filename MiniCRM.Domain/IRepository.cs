using System;

namespace MiniCRM.Domain
{
    public interface IRepository<TModel>
    {
        TModel GetById(Guid id);
        void Add(TModel entity);
        void Delete(Guid id);
        void Update(TModel entity);
        TModel[] GetAll();

    }
}
