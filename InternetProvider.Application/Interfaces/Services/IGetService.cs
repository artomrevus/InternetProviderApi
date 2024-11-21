using InternetProvider.GeneralTypes.Sort;

namespace InternetProvider.Application.Interfaces.Services;

public interface IGetService<TResponseDto>
{
    public Task<IEnumerable<TResponseDto>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize);
    
    public Task<int> CountAsync(Dictionary<string, object>? filter);
}