using InternetProvider.Domain.Entities;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class LocationTypeService(IUnitOfWork unitOfWork) : ILocationTypeService
{
    public async Task<LocationTypeOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.LocationTypes.GetByIdAsync(id);
        return repositoryEntity.ToDomainLocationTypeOutput();
    }

    public async Task<IEnumerable<LocationTypeOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.LocationTypes.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainLocationTypeOutput());
    }

    public async Task AddAsync(LocationTypeInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureLocationType();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.LocationTypes.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, LocationTypeInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureLocationType();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.LocationTypes.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.LocationTypes.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}