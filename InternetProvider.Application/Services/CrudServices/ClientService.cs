using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Exception;
using InternetProvider.Application.Mappers;
using InternetProvider.GeneralTypes.Sort;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.Application.Services.CrudServices;

public class ClientService(Domain.Interfaces.Services.IClientService domainService, UserManager<IdentityUser> userManager) : Application.Interfaces.Services.IClientService
{
    public async Task<ClientResponseDto> GetByIdAsync(int id)
    {
        var domainEntity = await domainService.GetByIdAsync(id);
        return domainEntity.ToClientResponseDto();
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAllAsync()
    {
        var domainEntities = await domainService.GetAllAsync();
        return domainEntities.Select(x => x.ToClientResponseDto());
    }

    public async Task AddAsync(ClientRequestDto entity)
    {
        await domainService.AddAsync(entity.ToDomainClientInput());
    }

    public async Task UpdateAsync(int id, ClientRequestDto entity)
    {
        await domainService.UpdateAsync(id, entity.ToDomainClientInput());
    }

    public async Task DeleteAsync(int id)
    {
        await domainService.DeleteAsync(id);
    }

    public async Task<bool> HasUserAccess(int accessedId, string userId)
    {
        var identityUser = await userManager.FindByIdAsync(userId);
        if (identityUser is null)
        {
            throw new AccessException($"No users found with id {userId}.");
        }
        
        var userRoles = await userManager.GetRolesAsync(identityUser);
        if (userRoles.Contains("Admin"))
        {
            return true;
        }

        if (userRoles.Contains("Client"))
        {
            return accessedId == await domainService.GetIdByUserIdAsync(userId);
        }

        return false;
    }

    public async Task<IEnumerable<ClientResponseDto>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        var domainEntities = await domainService.GetAsync(filter, sort, pageNumber, pageSize);
        return domainEntities.Select(x => x.ToClientResponseDto());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await domainService.CountAsync(filter);
    }
}