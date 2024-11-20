using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class LocationTypeService(Domain.Interfaces.Services.ILocationTypeService domainService) : Application.Interfaces.Services.ILocationTypeService
{
    public async Task<LocationTypeResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToLocationTypeResponseDto();
    }

    public async Task<IEnumerable<LocationTypeResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToLocationTypeResponseDto());
    }

    public async Task AddAsync(LocationTypeRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainLocationTypeInput());
    }

    public async Task UpdateAsync(int id, LocationTypeRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainLocationTypeInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}