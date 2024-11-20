using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class HouseService(Domain.Interfaces.Services.IHouseService domainService) : Application.Interfaces.Services.IHouseService
{
    public async Task<HouseResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToHouseResponseDto();
    }

    public async Task<IEnumerable<HouseResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToHouseResponseDto());
    }

    public async Task AddAsync(HouseRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainHouseInput());
    }

    public async Task UpdateAsync(int id, HouseRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainHouseInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}