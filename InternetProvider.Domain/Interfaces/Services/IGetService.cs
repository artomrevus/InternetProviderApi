using InternetProvider.GeneralTypes.Sort;

namespace InternetProvider.Domain.Interfaces.Services;

public interface IGetService<TOutput>
{
    public Task<IEnumerable<TOutput>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize);
    
    public Task<int> CountAsync(Dictionary<string, object>? filter);
}