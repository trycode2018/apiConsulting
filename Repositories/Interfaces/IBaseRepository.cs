namespace Consultorio.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task CreateAsync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(int id);
    }
}
