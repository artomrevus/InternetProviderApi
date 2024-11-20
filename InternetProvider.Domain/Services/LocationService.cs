using InternetProvider.Domain.Entities;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.GeneralTypes.Sort;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class LocationService(IUnitOfWork unitOfWork) : ILocationService
{
    public async Task<LocationOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.Locations.GetByIdAsync(id);
        return repositoryEntity.ToDomainLocationOutput();
    }

    public async Task<IEnumerable<LocationOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.Locations.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainLocationOutput());
    }

    public async Task AddAsync(LocationInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureLocation();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Locations.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, LocationInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureLocation();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Locations.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Locations.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<LocationOutput>> GetAsync(
        Dictionary<string, object>? filter,
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        var repositoryEntities = await unitOfWork.Locations.GetAsync(filter, sort, pageNumber, pageSize);
        return repositoryEntities.Select(x => x.ToDomainLocationOutput());
    }
    
    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.Locations.CountAsync(filter);
    }
}