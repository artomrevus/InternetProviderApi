using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetTariffStatusRepository(InternetProviderContext context) : IInternetTariffStatusRepository
{
    public async Task<IInternetTariffStatus> GetByIdAsync(int id)
    {
        var internetTariffStatus = await context.InternetTariffStatuses.FindAsync(id);
        if (internetTariffStatus is null)
        {
            throw new RepositoryException($"Internet tariff status with id {id} was not found");
        }

        return internetTariffStatus;
    }

    public Task<IEnumerable<IInternetTariffStatus>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<IInternetTariffStatus>>(context.InternetTariffStatuses);
    }

    public async Task AddAsync(IInternetTariffStatus entity)
    {
        if (entity is InternetTariffStatus internetTariffStatusEntity)
        {
            await context.InternetTariffStatuses.AddAsync(internetTariffStatusEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type InternetTariffStatus.");
        }
    }

    public async Task UpdateAsync(int id, IInternetTariffStatus entity)
    {
        var internetTariffStatus = await context.InternetTariffStatuses.FindAsync(id);
        if (internetTariffStatus is null)
        {
            throw new RepositoryException($"Internet tariff status with id {id} was not found");
        }
        
        internetTariffStatus.InternetTariffStatusName = entity.InternetTariffStatusName;
        internetTariffStatus.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var internetTariffStatus = await context.InternetTariffStatuses.FindAsync(id);
        if (internetTariffStatus is null)
        {
            throw new RepositoryException($"Internet tariff status with id {id} was not found");
        }
        
        context.InternetTariffStatuses.Remove(internetTariffStatus);
    }
}