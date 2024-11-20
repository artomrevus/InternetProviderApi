using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class CityRepository(InternetProviderContext context) : ICityRepository
{
    public async Task<City> GetByIdAsync(int id)
    {
        var city = await context.Cities.FindAsync(id);
        if (city is null)
        {
            throw new RepositoryException($"City with id {id} was not found");
        }

        return city;
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await context.Cities.ToListAsync();
    }

    public async Task AddAsync(City entity)
    {
        await context.Cities.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, City entity)
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