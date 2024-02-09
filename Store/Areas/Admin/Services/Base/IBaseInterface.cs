namespace Store.Areas.Admin.Services.Base
{
    public interface IBaseInterface<T>
    {
        List<T> GetAll();
        T ?GetById(int id);
        bool Create(T entity);
        bool Update(T entity,int id);
        bool Delete(int id);

    }
}
