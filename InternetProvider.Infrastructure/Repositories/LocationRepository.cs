using System.Linq.Expressions;
using InternetProvider.GeneralTypes.Sort;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using InternetProvider.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class LocationRepository(InternetProviderContext context) : ILocationRepository
{
    public async Task<Location> GetByIdAsync(int id)
    {
        var location = await context.Locations
            .Include(x => x.LocationType)
            .Include(x => x.House)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
            .FirstOrDefaultAsync(x => x.LocationId == id);
        
        if (location is null)
        {
            throw new RepositoryException($"Location with id {id} was not found");
        }

        return location;
    }

    public async Task<IEnumerable<Location>> GetAllAsync()
    {
        return await context.Locations
            .Include(x => x.LocationType)
            .Include(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City)
            .ToListAsync();
    }
    
    public async Task AddAsync(Location entity)
    {
        await context.Locations.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, Location entity)
    {
        var location = await context.Locations.FindAsync(id);
        if (location is null)
        {
            throw new RepositoryException($"Location with id {id} was not found");
        }
        
        location.LocationTypeId = entity.LocationTypeId;
        location.HouseId = entity.HouseId;
        location.ApartmentNumber = entity.ApartmentNumber;
        location.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var location = await context.Locations.FindAsync(id);
        if (location is null)
        {
            throw new RepositoryException($"Location with id {id} was not found");
        }
        
        context.Locations.Remove(location);
    }
    
    public Task<IEnumerable<Location>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort,
        int? pageNumber,
        int? pageSize)
    {
        IQueryable<Location> locations = context.Locations
            .Include(x => x.LocationType)
            .Include(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City);

        if (filter is not null)
        {
            locations = ApplyFilter(locations, filter);
        }
        
        if (sort is not null)
        {
            locations = ApplySort(locations, sort);
        }
        
        if (pageNumber is not null && pageSize is not null)
        {
            locations = ApplyPagination(locations, (int)pageNumber, (int)pageSize);
        }
        
        return Task.FromResult(locations.AsEnumerable());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        IQueryable<Location> locations = context.Locations
            .Include(x => x.LocationType)
            .Include(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City);

        if (filter is not null)
        {
            locations = ApplyFilter(locations, filter);
        }
        
        return await locations.CountAsync();
    }

    private IQueryable<Location> ApplyFilter(IQueryable<Location> locations, Dictionary<string, object> filters)
    {
        foreach (var filter in filters)
        {
            var filterKeyLower = filter.Key.ToLower();

            locations = filterKeyLower switch
            {
                "cityname" => locations.Where(x => x.House.Street.City.CityName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "streetname" => locations.Where(x => x.House.Street.StreetName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "housenumber" => locations.Where(x => x.House.HouseNumber!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "locationtypename" => locations.Where(x => x.LocationType.LocationTypeName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "apartmentnumbermin" => locations.Where(x => x.ApartmentNumber >= filter.Value.ToInt()),
                "apartmentnumbermax" => locations.Where(x => x.ApartmentNumber <= filter.Value.ToInt()),
                _ => throw new RepositoryException($"Filter {filter.Key} is not supported.")
            };
        }
        
        return locations;
    }

    private IQueryable<Location> ApplySort(IQueryable<Location> locations, Dictionary<string, SortType> sorts)
    {
        IOrderedQueryable<Location>? orderedLocations = null;

        foreach (var sort in sorts)
        {
            var sortFieldLower = sort.Key.ToLowerInvariant();
            
            Expression<Func<Location, object>> keySelector = sortFieldLower switch
            {
                "cityname" => x => x.House.Street.City.CityName!,
                "streetname" => x => x.House.Street.StreetName!,
                "housenumber" => x => x.House.HouseNumber!,
                "locationtypename" => x => x.LocationType.LocationTypeName!,
                "apartmentnumber" => x => x.ApartmentNumber!,
                _ => throw new RepositoryException($"Sort {sort.Key} is not supported.")
            };
            
            orderedLocations = orderedLocations is null
                ? locations.ApplyInitialSort(keySelector, sort.Value)
                : orderedLocations.ApplyThenBySort(keySelector, sort.Value);
        }

        return orderedLocations ?? locations;
    }

    private IQueryable<Location> ApplyPagination(IQueryable<Location> locations, int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new RepositoryException($"Page number {pageNumber} or page size {pageSize} incorrect.");
        }
        
        return locations.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}