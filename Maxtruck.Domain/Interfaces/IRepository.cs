using Maxtruck.Domain.Models;

namespace Maxtruck.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
