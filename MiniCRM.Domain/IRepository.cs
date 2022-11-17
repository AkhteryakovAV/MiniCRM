namespace MiniCRM.Domain
{
    public interface IRepository<TModel>
    {
        TModel GetById(int id);
        void Add(TModel entity);
        void Delete(int id);
        void Update(TModel entity);
        TModel[] GetAll();

    }
}
