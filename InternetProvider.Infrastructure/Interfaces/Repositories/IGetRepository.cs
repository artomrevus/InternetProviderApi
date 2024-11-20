using InternetProvider.GeneralTypes.Sort;

namespace InternetProvider.Infrastructure.Interfaces.Repositories;

public interface IGetRepository<T>
{
    public Task<IEnumerable<T>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize);
    
    public Task<int> CountAsync(Dictionary<string, object>? filter);
}