using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Repositories;

public class HouseRepository(InternetProviderContext context) : IHouseRepository
{
    public async Task<House> GetByIdAsync(int id)
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

    public Task<IEnumerable<House>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<House>>(context.Houses
            .Include(x => x.Street)
            .ThenInclude(x => x.City));
    }

    public async Task AddAsync(House entity)
    {
        await context.Houses.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, House entity)
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