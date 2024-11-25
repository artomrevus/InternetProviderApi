using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;
using InternetProvider.Abstraction.Sort;

namespace InternetProvider.Domain.Services;

public class InternetConnectionRequestService(IUnitOfWork unitOfWork) : IInternetConnectionRequestService
{
    public async Task<IInternetConnectionRequest> GetByIdAsync(int id)
    {
        return await unitOfWork.InternetConnectionRequests.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IInternetConnectionRequest>> GetAllAsync()
    {
        return await unitOfWork.InternetConnectionRequests.GetAllAsync();
    }

    public async Task AddAsync(IInternetConnectionRequest entity)
    {
        entity.RequestDate = DateOnly.FromDateTime(DateTime.UtcNow);
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetConnectionRequests.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IInternetConnectionRequest entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetConnectionRequests.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetConnectionRequests.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<IInternetConnectionRequest>> GetAsync(Dictionary<string, object>? filter, Dictionary<string, SortType>? sort, int? pageNumber, int? pageSize)
    {
        return await unitOfWork.InternetConnectionRequests.GetAsync(filter, sort, pageNumber, pageSize);
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.InternetConnectionRequests.CountAsync(filter);
    }
}