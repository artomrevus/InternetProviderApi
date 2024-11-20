using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class LocationTypeRepository(InternetProviderContext context) : ILocationTypeRepository
{
    public async Task<LocationType> GetByIdAsync(int id)
    {
        var locationType = await context.LocationTypes.FindAsync(id);
        if (locationType is null)
        {
            throw new RepositoryException($"Location type with id {id} was not found");
        }

        return locationType;
    }

    public async Task<IEnumerable<LocationType>> GetAllAsync()
    {
        return await context.LocationTypes.ToListAsync();
    }

    public async Task AddAsync(LocationType entity)
    {
        await context.LocationTypes.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, LocationType entity)
    {
        var locationType = await context.LocationTypes.FindAsync(id);
        if (locationType is null)
        {
            throw new RepositoryException($"Location type with id {id} was not found");
        }
        
        locationType.LocationTypeName = entity.LocationTypeName;
        locationType.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var locationType = await context.LocationTypes.FindAsync(id);
        if (locationType is null)
        {
            throw new RepositoryException($"Location type with id {id} was not found");
        }
        
        context.LocationTypes.Remove(locationType);
    }
}