using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class InternetTariffStatusService(Domain.Interfaces.Services.IInternetTariffStatusService domainService) : IInternetTariffStatusService
{
    public async Task<InternetTariffStatusResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToInternetTariffStatusResponseDto();
    }

    public async Task<IEnumerable<InternetTariffStatusResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToInternetTariffStatusResponseDto());
    }

    public async Task AddAsync(InternetTariffStatusRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainInternetTariffStatusInput());
    }

    public async Task UpdateAsync(int id, InternetTariffStatusRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainInternetTariffStatusInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}