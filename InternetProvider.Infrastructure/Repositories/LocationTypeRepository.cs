using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class LocationTypeRepository(InternetProviderContext context) : ILocationTypeRepository
{
    public async Task<ILocationType> GetByIdAsync(int id)
    {
        var locationType = await context.LocationTypes.FindAsync(id);
        if (locationType is null)
        {
            throw new RepositoryException($"Location type with id {id} was not found");
        }

        return locationType;
    }

    public async Task<IEnumerable<ILocationType>> GetAllAsync()
    {
        return await context.LocationTypes.ToListAsync();
    }

    public async Task AddAsync(ILocationType entity)
    {
        if (entity is LocationType locationTypeEntity)
        {
            await context.LocationTypes.AddAsync(locationTypeEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type LocationType.");
        }
    }

    public async Task UpdateAsync(int id, ILocationType entity)
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