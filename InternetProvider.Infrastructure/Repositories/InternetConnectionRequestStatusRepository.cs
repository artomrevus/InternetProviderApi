using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Exceptions;
using InternetProvider.Infrastructure.Interfaces.Repositories;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetConnectionRequestStatusRepository(InternetProviderContext context) : IInternetConnectionRequestStatusRepository
{
    public async Task<InternetConnectionRequestStatus> GetByIdAsync(int id)
    {
        var internetConnectionRequestStatus = await context.InternetConnectionRequestStatuses.FindAsync(id);
        if (internetConnectionRequestStatus is null)
        {
            throw new RepositoryException($"Internet connection request status with id {id} was not found");
        }

        return internetConnectionRequestStatus;
    }

    public Task<IEnumerable<InternetConnectionRequestStatus>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<InternetConnectionRequestStatus>>(context.InternetConnectionRequestStatuses);
    }

    public async Task AddAsync(InternetConnectionRequestStatus entity)
    {
        await context.InternetConnectionRequestStatuses.AddAsync(entity);
    }

    public async Task UpdateAsync(int id, InternetConnectionRequestStatus entity)
    {
        var internetConnectionRequestStatus = await context.InternetConnectionRequestStatuses.FindAsync(id);
        if (internetConnectionRequestStatus is null)
        {
            throw new RepositoryException($"Internet connection request status with id {id} was not found");
        }
        
        internetConnectionRequestStatus.InternetConnectionRequestStatusName = entity.InternetConnectionRequestStatusName;
        internetConnectionRequestStatus.UpdateDateTime = entity.UpdateDateTime;
    }

    public async Task DeleteAsync(int id)
    {
        var internetConnectionRequestStatus = await context.InternetConnectionRequestStatuses.FindAsync(id);
        if (internetConnectionRequestStatus is null)
        {
            throw new RepositoryException($"Internet connection request status with id {id} was not found");
        }
        
        context.InternetConnectionRequestStatuses.Remove(internetConnectionRequestStatus);
    }
}