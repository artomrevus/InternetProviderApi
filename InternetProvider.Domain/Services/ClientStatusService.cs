using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class ClientStatusService(IUnitOfWork unitOfWork) : IClientStatusService
{
    public async Task<IClientStatus> GetByIdAsync(int id)
    {
        return await unitOfWork.ClientStatuses.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IClientStatus>> GetAllAsync()
    {
        return await unitOfWork.ClientStatuses.GetAllAsync();
    }

    public async Task AddAsync(IClientStatus entity)
    {
        var entities = await unitOfWork.ClientStatuses.GetAllAsync();
        var entitiesList = entities.ToList();
        
        var lastEntityId = entitiesList.Count != 0 ? entitiesList.Last().ClientStatusId : 0;
        
        entity.ClientStatusId = lastEntityId + 1;
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.ClientStatuses.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IClientStatus entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.ClientStatuses.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.ClientStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}