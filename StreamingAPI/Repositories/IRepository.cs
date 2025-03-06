using StreamingAPI.Repositories;

namespace StreamingAPI.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetByID(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
