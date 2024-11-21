using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class InternetConnectionRequestStatusService(Domain.Interfaces.Services.IInternetConnectionRequestStatusService domainService) : IInternetConnectionRequestStatusService
{
    public async Task<InternetConnectionRequestStatusResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToInternetConnectionRequestStatusResponseDto();
    }

    public async Task<IEnumerable<InternetConnectionRequestStatusResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToInternetConnectionRequestStatusResponseDto());
    }

    public async Task AddAsync(InternetConnectionRequestStatusRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainInternetConnectionRequestStatusInput());
    }

    public async Task UpdateAsync(int id, InternetConnectionRequestStatusRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainInternetConnectionRequestStatusInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}