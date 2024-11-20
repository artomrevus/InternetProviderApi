namespace InternetProvider.Application.Interfaces.Services;

public interface IAppCrudService<TRequestDto, TResponseDto>
    where TRequestDto : class
    where TResponseDto : class
{
    Task<TResponseDto> GetByIdAsync(int id);
    Task<IEnumerable<TResponseDto>> GetAllAsync();
    Task AddAsync(TRequestDto entity);
    Task UpdateAsync(int id, TRequestDto entity);
    Task DeleteAsync(int id);
}