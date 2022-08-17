namespace MediatRSample.API.Application.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
