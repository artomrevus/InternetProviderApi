using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetTariffRepository(InternetProviderContext context) : IInternetTariffRepository
{
    public async Task<InternetTariff> GetByIdAsync(int id)
    {
        var internetTariff = await context.InternetTariffs
            .Include(x => x.InternetTariffStatus)
            .Include(x => x.LocationType)
            .FirstOrDefaultAsync(x => x.InternetTariffId == id);
        
        if (internetTariff is null)
        {
            throw new RepositoryException($"Internet tariff with id {id} was not found");
        }

        return internetTariff;
    }

    public Task<IEnumerable<InternetTariff>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<InternetTariff>>(context.InternetTariffs
            .Include(x => x.InternetTariffStatus)
            .Include(x => x.LocationType));
    }

    public async Task AddAsync(InternetTariff entity)
    {
        await context.InternetTariffs.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, InternetTariff entity)
    {
        var internetTariff = await context.InternetTariffs.FindAsync(id);
        if (internetTariff is null)
        {
            throw new RepositoryException($"Internet tariff with id {id} was not found");
        }
        
        internetTariff.InternetTariffStatusId = entity.InternetTariffStatusId;
        internetTariff.LocationTypeId = entity.LocationTypeId;
        internetTariff.Name = entity.Name;
        internetTariff.Price = entity.Price;
        internetTariff.InternetSpeedMbits = entity.InternetSpeedMbits;
        internetTariff.Description = entity.Description;
        internetTariff.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var internetTariff = await context.InternetTariffs.FindAsync(id);
        if (internetTariff is null)
        {
            throw new RepositoryException($"Internet tariff with id {id} was not found");
        }
        
        context.InternetTariffs.Remove(internetTariff);
    }
}