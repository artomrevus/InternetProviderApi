using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class InternetTariffStatusService(IUnitOfWork unitOfWork) : IInternetTariffStatusService
{
    public async Task<IInternetTariffStatus> GetByIdAsync(int id)
    {
        return await unitOfWork.InternetTariffStatuses.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IInternetTariffStatus>> GetAllAsync()
    {
        return await unitOfWork.InternetTariffStatuses.GetAllAsync();
    }

    public async Task AddAsync(IInternetTariffStatus entity)
    {
        var entities = await unitOfWork.InternetTariffStatuses.GetAllAsync();
        var entitiesList = entities.ToList();
        
        var lastEntityId = entitiesList.Count != 0 ? entitiesList.Last().InternetTariffStatusId : 0;
        
        entity.InternetTariffStatusId = lastEntityId + 1;
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetTariffStatuses.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IInternetTariffStatus entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetTariffStatuses.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetTariffStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}