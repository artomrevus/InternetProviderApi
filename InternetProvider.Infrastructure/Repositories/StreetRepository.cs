using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class StreetRepository(InternetProviderContext context) : IStreetRepository
{
    public async Task<Street> GetByIdAsync(int id)
    {
        var street = await context.Streets
            .Include(x => x.City)
            .FirstOrDefaultAsync(x=> x.StreetId == id);
        
        if (street is null)
        {
            throw new RepositoryException($"Street with id {id} was not found");
        }

        return street;
    }

    public async Task<IEnumerable<Street>> GetAllAsync()
    {
        return await context.Streets
            .Include(x => x.City)
            .ToListAsync();
    }

    public async Task AddAsync(Street entity)
    {
        await context.Streets.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, Street entity)
    {
        var street = await context.Streets.FindAsync(id);
        if (street is null)
        {
            throw new RepositoryException($"Street with id {id} was not found");
        }
        
        street.CityId = entity.CityId;
        street.StreetName = entity.StreetName;
        street.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var street = await context.Streets.FindAsync(id);
        if (street is null)
        {
            throw new RepositoryException($"Street with id {id} was not found");
        }
        
        context.Streets.Remove(street);
    }
}