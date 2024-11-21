using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetTariffStatusRepository(InternetProviderContext context) : IInternetTariffStatusRepository
{
    public async Task<InternetTariffStatus> GetByIdAsync(int id)
    {
        var internetTariffStatus = await context.InternetTariffStatuses.FindAsync(id);
        if (internetTariffStatus is null)
        {
            throw new RepositoryException($"Internet tariff status with id {id} was not found");
        }

        return internetTariffStatus;
    }

    public Task<IEnumerable<InternetTariffStatus>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<InternetTariffStatus>>(context.InternetTariffStatuses);
    }

    public async Task AddAsync(InternetTariffStatus entity)
    {
        await context.InternetTariffStatuses.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, InternetTariffStatus entity)
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