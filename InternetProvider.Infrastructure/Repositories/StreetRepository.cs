using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class StreetRepository(InternetProviderContext context) : IStreetRepository
{
    public async Task<IStreet> GetByIdAsync(int id)
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

    public async Task<IEnumerable<IStreet>> GetAllAsync()
    {
        return await context.Streets
            .Include(x => x.City)
            .ToListAsync();
    }

    public async Task AddAsync(IStreet entity)
    {
        if (entity is Street streetEntity)
        {
            await context.Streets.AddAsync(streetEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type Street.");
        }
    }

    public async Task UpdateAsync(int id, IStreet entity)
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