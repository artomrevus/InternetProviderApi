using InternetProvider.Abstraction.Sort;

namespace InternetProvider.Abstraction.Services;

public interface IGetService<T>
{
    public Task<IEnumerable<T>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize);
    
    public Task<int> CountAsync(Dictionary<string, object>? filter);
}