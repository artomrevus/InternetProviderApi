using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Repositories;

public class ClientStatusRepository(InternetProviderContext context) : IClientStatusRepository
{
    public async Task<IClientStatus> GetByIdAsync(int id)
    {
        var clientStatus = await context.ClientStatuses.FindAsync(id);
        if (clientStatus is null)
        {
            throw new RepositoryException($"Client status with id {id} was not found");
        }

        return clientStatus;
    }

    public Task<IEnumerable<IClientStatus>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<IClientStatus>>(context.ClientStatuses);
    }

    public async Task AddAsync(IClientStatus entity)
    {
        if (entity is ClientStatus clientStatusEntity)
        {
            await context.ClientStatuses.AddAsync(clientStatusEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type ClientStatus.");
        }
    }

    public async Task UpdateAsync(int id, IClientStatus entity)
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