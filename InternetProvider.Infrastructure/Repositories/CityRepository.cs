using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class CityRepository(InternetProviderContext context) : ICityRepository
{
    public async Task<ICity> GetByIdAsync(int id)
    {
        var city = await context.Cities.FindAsync(id);
        if (city is null)
        {
            throw new RepositoryException($"City with id {id} was not found");
        }

        return city;
    }

    public async Task<IEnumerable<ICity>> GetAllAsync()
    {
        return await context.Cities.ToListAsync();
    }

    public async Task AddAsync(ICity entity)
    {
        if (entity is City cityEntity)
        {
            await context.Cities.AddAsync(cityEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type City.");
        }
    }

    public async Task UpdateAsync(int id, ICity entity)
    {
        var city = await context.Cities.FindAsync(id);
        if (city is null)
        {
            throw new RepositoryException($"City with id {id} was not found");
        }
        
        city.CityName = entity.CityName;
        city.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var city = await context.Cities.FindAsync(id);
        if (city is null)
        {
            throw new RepositoryException($"City with id {id} was not found");
        }
        
        context.Cities.Remove(city);
    }
}