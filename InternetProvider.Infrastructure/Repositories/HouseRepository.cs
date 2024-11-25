using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class HouseRepository(InternetProviderContext context) : IHouseRepository
{
    public async Task<IHouse> GetByIdAsync(int id)
    {
        var house = await context.Houses
            .Include(x => x.Street)
            .ThenInclude(x => x.City)
            .FirstOrDefaultAsync(x => x.HouseId == id);
        
        if (house is null)
        {
            throw new RepositoryException($"House with id {id} was not found");
        }

        return house;
    }

    public Task<IEnumerable<IHouse>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<IHouse>>(context.Houses
            .Include(x => x.Street)
            .ThenInclude(x => x.City));
    }

    public async Task AddAsync(IHouse entity)
    {
        if (entity is House houseEntity)
        {
            await context.Houses.AddAsync(houseEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type House.");
        }
    }

    public async Task UpdateAsync(int id, IHouse entity)
    {
        var house = await context.Houses.FindAsync(id);
        if (house is null)
        {
            throw new RepositoryException($"House with id {id} was not found");
        }
        
        house.StreetId = entity.StreetId;
        house.HouseNumber = entity.HouseNumber;
        house.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var house = await context.Houses.FindAsync(id);
        if (house is null)
        {
            throw new RepositoryException($"House with id {id} was not found");
        }
        
        context.Houses.Remove(house);
    }
}