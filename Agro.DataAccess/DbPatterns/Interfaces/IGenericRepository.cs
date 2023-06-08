namespace Agro.DataAccess.DbPatterns.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T t);
        Task<IList<T>> CreateRange(IList<T> t);
        Task Delete(T t);
        Task Update(T t);
        Task<T> Get(int id);
        Task<IList<T>> GetAll();
    }
}
