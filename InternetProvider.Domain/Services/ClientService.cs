using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;
using InternetProvider.Abstraction.Sort;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.Domain.Services;

public class ClientService(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager) : IClientService
{
    public async Task<IClient> GetByIdAsync(int id)
    {
        return await unitOfWork.Clients.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IClient>> GetAllAsync()
    {
        return await unitOfWork.Clients.GetAllAsync();
    }

    public async Task AddAsync(IClient entity)
    {
        entity.RegistrationDate = DateOnly.FromDateTime(DateTime.UtcNow);
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Clients.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IClient entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Clients.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Clients.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<int> GetIdByUserIdAsync(string userId)
    {
        return await unitOfWork.Clients.GetIdByUserIdAsync(userId);
    }

    public async Task<IEnumerable<IClient>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        return await unitOfWork.Clients.GetAsync(filter, sort, pageNumber, pageSize);
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.Clients.CountAsync(filter);
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
            return accessedId == await this.GetIdByUserIdAsync(userId);
        }

        return false;
    }
}