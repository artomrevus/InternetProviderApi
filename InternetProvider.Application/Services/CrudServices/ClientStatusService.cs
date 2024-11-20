using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Mappers;

namespace InternetProvider.Application.Services.CrudServices;

public class ClientStatusService(Domain.Interfaces.Services.IClientStatusService domainService) : Application.Interfaces.Services.IClientStatusService
{
    public async Task<ClientStatusResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToClientStatusResponseDto();
    }

    public async Task<IEnumerable<ClientStatusResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToClientStatusResponseDto());
    }

    public async Task AddAsync(ClientStatusRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainClientStatusInput());
    }

    public async Task UpdateAsync(int id, ClientStatusRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainClientStatusInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }
}