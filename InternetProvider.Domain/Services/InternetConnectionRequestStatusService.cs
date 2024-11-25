using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class InternetConnectionRequestStatusService(IUnitOfWork unitOfWork) : IInternetConnectionRequestStatusService
{
    public async Task<IInternetConnectionRequestStatus> GetByIdAsync(int id)
    {
        return await unitOfWork.InternetConnectionRequestStatuses.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IInternetConnectionRequestStatus>> GetAllAsync()
    {
        return await unitOfWork.InternetConnectionRequestStatuses.GetAllAsync();
    }

    public async Task AddAsync(IInternetConnectionRequestStatus entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetConnectionRequestStatuses.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IInternetConnectionRequestStatus entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetConnectionRequestStatuses.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetConnectionRequestStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}