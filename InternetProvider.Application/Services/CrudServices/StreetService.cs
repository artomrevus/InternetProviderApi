using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class StreetService(Domain.Interfaces.Services.IStreetService domainService) : Application.Interfaces.Services.IStreetService
{
    public async Task<StreetResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToStreetResponseDto();
    }

    public async Task<IEnumerable<StreetResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToStreetResponseDto());
    }

    public async Task AddAsync(StreetRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainStreetInput());
    }

    public async Task UpdateAsync(int id, StreetRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainStreetInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}