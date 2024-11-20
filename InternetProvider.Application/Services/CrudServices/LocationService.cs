using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;
using InternetProvider.GeneralTypes.Sort;

namespace InternetProvider.Application.Services.CrudServices;

public class LocationService(Domain.Interfaces.Services.ILocationService domainService) : Application.Interfaces.Services.ILocationService
{
    public async Task<LocationResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToLocationResponseDto();
    }

    public async Task<IEnumerable<LocationResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToLocationResponseDto());
    }

    public async Task AddAsync(LocationRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainLocationInput());
    }

    public async Task UpdateAsync(int id, LocationRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainLocationInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }

    public async Task<IEnumerable<LocationResponseDto>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        var domainEntities = await domainService.GetAsync(filter, sort, pageNumber, pageSize);
        return domainEntities.Select(x => x.ToLocationResponseDto());
    }
    
    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await domainService.CountAsync(filter);
    }
}