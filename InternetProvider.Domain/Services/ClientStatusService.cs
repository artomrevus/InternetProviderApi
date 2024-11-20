using InternetProvider.Domain.Entities;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class ClientStatusService(IUnitOfWork unitOfWork) : IClientStatusService
{
    public async Task<ClientStatusOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.ClientStatuses.GetByIdAsync(id);
        return repositoryEntity.ToDomainClientStatusOutput();
    }

    public async Task<IEnumerable<ClientStatusOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.ClientStatuses.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainClientStatusOutput());
    }

    public async Task AddAsync(ClientStatusInput entity)
    {
        var entities = (await unitOfWork.ClientStatuses.GetAllAsync()).ToList();
        var lastEntityId = entities.Any() ? entities.Last().ClientStatusId : 0;
        
        var repositoryEntity = entity.ToInfrastructureClientStatus();
        repositoryEntity.ClientStatusId = lastEntityId + 1;
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.ClientStatuses.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, ClientStatusInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureClientStatus();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.ClientStatuses.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.ClientStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}