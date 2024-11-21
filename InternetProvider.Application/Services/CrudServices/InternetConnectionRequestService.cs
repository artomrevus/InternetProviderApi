using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Application.Mappers;
using InternetProvider.GeneralTypes.Sort;

namespace InternetProvider.Application.Services.CrudServices;

public class InternetConnectionRequestService(Domain.Interfaces.Services.IInternetConnectionRequestService domainService) : IInternetConnectionRequestService
{
    public async Task<InternetConnectionRequestResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToInternetConnectionRequestResponseDto();
    }

    public async Task<IEnumerable<InternetConnectionRequestResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToInternetConnectionRequestResponseDto());
    }

    public async Task AddAsync(InternetConnectionRequestRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainInternetConnectionRequestInput());
    }

    public async Task UpdateAsync(int id, InternetConnectionRequestRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainInternetConnectionRequestInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }

    public async Task<IEnumerable<InternetConnectionRequestResponseDto>> GetAsync(Dictionary<string, object>? filter, Dictionary<string, SortType>? sort, int? pageNumber, int? pageSize)
    {
        var domainEntities = await domainService.GetAsync(filter, sort, pageNumber, pageSize);
        return domainEntities.Select(x => x.ToInternetConnectionRequestResponseDto());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await domainService.CountAsync(filter);
    }
}