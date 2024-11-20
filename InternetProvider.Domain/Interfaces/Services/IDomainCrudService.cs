namespace InternetProvider.Domain.Interfaces.Services;

public interface IDomainCrudService<TInput, TOutput>
    where TInput : class
    where TOutput : class
{
    Task<TOutput> GetByIdAsync(int id);
    Task<IEnumerable<TOutput>> GetAllAsync();
    Task AddAsync(TInput entity);
    Task UpdateAsync(int id, TInput entity);
    Task DeleteAsync(int id);
}