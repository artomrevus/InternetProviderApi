using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class CityService(Domain.Interfaces.Services.ICityService domainService) : Application.Interfaces.Services.ICityService
{
    public async Task<CityResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToCityResponseDto();
    }

    public async Task<IEnumerable<CityResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToCityResponseDto());
    }

    public async Task AddAsync(CityRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainCityInput());
    }

    public async Task UpdateAsync(int id, CityRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainCityInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}