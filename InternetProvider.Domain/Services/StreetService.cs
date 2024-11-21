using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class StreetService(IUnitOfWork unitOfWork) : IStreetService
{
    public async Task<StreetOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.Streets.GetByIdAsync(id);
        return repositoryEntity.ToDomainStreetOutput();
    }

    public async Task<IEnumerable<StreetOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.Streets.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainStreetOutput());
    }

    public async Task AddAsync(StreetInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureStreet();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Streets.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, StreetInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureStreet();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Streets.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Streets.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}