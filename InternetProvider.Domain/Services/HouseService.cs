using InternetProvider.Domain.Entities;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class HouseService(IUnitOfWork unitOfWork) : IHouseService
{
    public async Task<HouseOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.Houses.GetByIdAsync(id);
        return repositoryEntity.ToDomainHouseOutput();
    }

    public async Task<IEnumerable<HouseOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.Houses.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainHouseOutput());
    }

    public async Task AddAsync(HouseInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureHouse();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Houses.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, HouseInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureHouse();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Houses.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Houses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}