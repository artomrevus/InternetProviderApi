using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class InternetTariffService(Domain.Interfaces.Services.IInternetTariffService domainService) : IInternetTariffService
{
    public async Task<InternetTariffResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToInternetTariffResponseDto();
    }

    public async Task<IEnumerable<InternetTariffResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToInternetTariffResponseDto());
    }

    public async Task AddAsync(InternetTariffRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainInternetTariffInput());
    }

    public async Task UpdateAsync(int id, InternetTariffRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainInternetTariffInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}