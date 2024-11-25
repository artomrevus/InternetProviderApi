using System.Linq.Expressions;
using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Sort;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using InternetProvider.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class ClientRepository(InternetProviderContext context) : IClientRepository
{
    public async Task<IClient> GetByIdAsync(int id)
    {
        var client = await context.Clients
            .Include(x => x.ClientStatus)
            .Include(x => x.Location)
            .ThenInclude(x => x.LocationType)
            .Include(x => x.Location)
            .ThenInclude(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City)
            .FirstOrDefaultAsync(x => x.ClientId == id);
        
        if (client is null)
        {
            throw new RepositoryException($"Client with id {id} was not found");
        }

        return client;
    }

    public async Task<IEnumerable<IClient>> GetAllAsync()
    {
        return await context.Clients
            .Include(x => x.ClientStatus)
            .Include(x => x.Location)
            .ThenInclude(x => x.LocationType)
            .Include(x => x.Location)
            .ThenInclude(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City)
            .ToListAsync();
    }

    public async Task AddAsync(IClient entity)
    {
        if (entity is Client clientEntity)
        {
            await context.Clients.AddAsync(clientEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type Client.");
        }
    }

    public async Task UpdateAsync(int id, IClient entity)
    {
        var client = await context.Clients.FindAsync(id);
        if (client is null)
        {
            throw new RepositoryException($"Client with id {id} was not found");
        }
        
        client.ClientStatusId = entity.ClientStatusId;
        client.LocationId = entity.LocationId;
        client.FirstName = entity.FirstName;
        client.LastName = entity.LastName;
        client.PhoneNumber = entity.PhoneNumber;
        client.Email = entity.Email;
        client.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var client = await context.Clients.FindAsync(id);
        if (client is null)
        {
            throw new RepositoryException($"Client with id {id} was not found");
        }
        
        context.Clients.Remove(client);
    }

    public async Task<int> GetIdByUserIdAsync(string userId)
    {
        var client = await context.Clients.FirstOrDefaultAsync(x => x.UserId == userId);
        
        if (client is null)
        {
            throw new RepositoryException($"Client with userId {userId} was not found");
        }

        return client.ClientId;
    }
    
    public Task<IEnumerable<IClient>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        IQueryable<IClient> clients = context.Clients
            .Include(x => x.ClientStatus)
            .Include(x => x.Location)
            .ThenInclude(x => x.LocationType)
            .Include(x => x.Location)
            .ThenInclude(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City);

        if (filter is not null)
        {
            clients = ApplyFilter(clients, filter);
        }
        
        if (sort is not null)
        {
            clients = ApplySort(clients, sort);
        }
        
        if (pageNumber is not null && pageSize is not null)
        {
            clients = ApplyPagination(clients, (int)pageNumber, (int)pageSize);
        }
        
        return Task.FromResult(clients.AsEnumerable());
    }
    
    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        IQueryable<IClient> clients = context.Clients
            .Include(x => x.ClientStatus)
            .Include(x => x.Location)
            .ThenInclude(x => x.LocationType)
            .Include(x => x.Location)
            .ThenInclude(x => x.House)
            .ThenInclude(x => x.Street)
            .ThenInclude(x => x.City);

        if (filter is not null)
        {
            clients = ApplyFilter(clients, filter);
        }
        
        return await clients.CountAsync();
    }

    private IQueryable<IClient> ApplyFilter(IQueryable<IClient> clients, Dictionary<string, object> filters)
    {
        foreach (var filter in filters)
        {
            var filterKeyLower = filter.Key.ToLower();

            clients = filterKeyLower switch
            {
                "clientstatusname" => clients.Where(x => x.ClientStatus.ClientStatusName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "locationtypename" => clients.Where(x => x.Location.LocationType.LocationTypeName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "cityname" => clients.Where(x => x.Location.House.Street.City.CityName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "streetname" => clients.Where(x => x.Location.House.Street.StreetName!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "housenumber" => clients.Where(x => x.Location.House.HouseNumber!.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "firstname" => clients.Where(x => x.FirstName.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "lastname" => clients.Where(x => x.LastName.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "phonenumber" => clients.Where(x => x.PhoneNumber.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "email" => clients.Where(x => x.Email.ToLower().Contains(filter.Value.ToStr().ToLower())),
                "apartmentnumbermin" => clients.Where(x => x.Location.ApartmentNumber >= filter.Value.ToInt()),
                "apartmentnumbermax" => clients.Where(x => x.Location.ApartmentNumber <= filter.Value.ToInt()),
                "registrationdatemin" => clients.Where(x => x.RegistrationDate >= filter.Value.ToDateOnly()),
                "registrationdatemax" => clients.Where(x => x.RegistrationDate <= filter.Value.ToDateOnly()),
                _ => throw new RepositoryException($"Filter {filter.Key} is not supported.")
            };
        }
        
        return clients;
    }
    
    private IQueryable<IClient> ApplySort(IQueryable<IClient> clients, Dictionary<string, SortType> sorts)
    {
        IOrderedQueryable<IClient>? orderedClients = null;

        foreach (var sort in sorts)
        {
            var sortFieldLower = sort.Key.ToLowerInvariant();
            
            Expression<Func<IClient, object>> keySelector = sortFieldLower switch
            {
                "clientstatusname" => x => x.ClientStatus.ClientStatusName!,
                "locationtypename" => x => x.Location.LocationType.LocationTypeName!,
                "cityname" => x => x.Location.House.Street.City.CityName!,
                "streetname" => x => x.Location.House.Street.StreetName!,
                "housenumber" => x => x.Location.House.HouseNumber!,
                "firstname" => x => x.FirstName,
                "lastname" => x => x.LastName,
                "phonenumber" => x => x.PhoneNumber,
                "email" => x => x.Email,
                "apartmentnumber" => x => x.Location.ApartmentNumber!,
                "registrationdate" => x => x.RegistrationDate,
                _ => throw new RepositoryException($"Sort {sort.Key} is not supported.")
            };
            
            orderedClients = orderedClients is null
                ? clients.ApplyInitialSort(keySelector, sort.Value)
                : orderedClients.ApplyThenBySort(keySelector, sort.Value);
        }

        return orderedClients ?? clients;
    }

    private IQueryable<IClient> ApplyPagination(IQueryable<IClient> clients, int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new RepositoryException($"Page number {pageNumber} or page size {pageSize} incorrect.");
        }
        
        return clients.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}