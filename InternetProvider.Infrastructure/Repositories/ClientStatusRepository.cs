using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class ClientStatusRepository(InternetProviderContext context) : IClientStatusRepository
{
    public async Task<ClientStatus> GetByIdAsync(int id)
    {
        var clientStatus = await context.ClientStatuses.FindAsync(id);
        if (clientStatus is null)
        {
            throw new RepositoryException($"Client status with id {id} was not found");
        }

        return clientStatus;
    }

    public async Task<IEnumerable<ClientStatus>> GetAllAsync()
    {
        return await context.ClientStatuses.ToListAsync();
    }

    public async Task AddAsync(ClientStatus entity)
    {
        await context.ClientStatuses.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, ClientStatus entity)
    {
        var clientStatus = await context.ClientStatuses.FindAsync(id);
        if (clientStatus is null)
        {
            throw new RepositoryException($"Client status with id {id} was not found");
        }
        
        clientStatus.ClientStatusName = entity.ClientStatusName;
        clientStatus.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var clientStatus = await context.ClientStatuses.FindAsync(id);
        if (clientStatus is null)
        {
            throw new RepositoryException($"Client status with id {id} was not found");
        }
        
        context.ClientStatuses.Remove(clientStatus);
    }
}