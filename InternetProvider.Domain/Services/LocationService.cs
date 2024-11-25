using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;
using InternetProvider.Abstraction.Sort;

namespace InternetProvider.Domain.Services;

public class LocationService(IUnitOfWork unitOfWork) : ILocationService
{
    public async Task<ILocation> GetByIdAsync(int id)
    {
        return await unitOfWork.Locations.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ILocation>> GetAllAsync()
    {
        return await unitOfWork.Locations.GetAllAsync();
    }

    public async Task AddAsync(ILocation entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Locations.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, ILocation entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Locations.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Locations.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<ILocation>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        return await unitOfWork.Locations.GetAsync(filter, sort, pageNumber, pageSize);
    }
    
    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.Locations.CountAsync(filter);
    }
}