using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class CityService(IUnitOfWork unitOfWork) : ICityService
{
    public async Task<CityOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.Cities.GetByIdAsync(id);
        return repositoryEntity.ToDomainCityOutput();
    }

    public async Task<IEnumerable<CityOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.Cities.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainCityOutput());
    }

    public async Task AddAsync(CityInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureCity();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Cities.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, CityInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureCity();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Cities.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Cities.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}