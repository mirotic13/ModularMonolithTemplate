using ModularMonolithTemplate.SharedKernel.Domain;

namespace ModularMonolithTemplate.SharedKernel.Abstractions;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangesAsync();
}
