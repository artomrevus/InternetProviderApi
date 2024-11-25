using InternetProvider.Abstraction.Sort;

namespace InternetProvider.Abstraction.Repositories;

public interface IGetRepository<T>
{
    public Task<IEnumerable<T>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize);
    
    public Task<int> CountAsync(Dictionary<string, object>? filter);
}