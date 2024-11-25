using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Infrastructure.Repositories;

public class InternetConnectionRequestStatusRepository(InternetProviderContext context) : IInternetConnectionRequestStatusRepository
{
    public async Task<IInternetConnectionRequestStatus> GetByIdAsync(int id)
    {
        var internetConnectionRequestStatus = await context.InternetConnectionRequestStatuses.FindAsync(id);
        if (internetConnectionRequestStatus is null)
        {
            throw new RepositoryException($"Internet connection request status with id {id} was not found");
        }

        return internetConnectionRequestStatus;
    }

    public Task<IEnumerable<IInternetConnectionRequestStatus>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<IInternetConnectionRequestStatus>>(context.InternetConnectionRequestStatuses);
    }

    public async Task AddAsync(IInternetConnectionRequestStatus entity)
    {
        if (entity is InternetConnectionRequestStatus internetConnectionRequestStatusEntity)
        {
            await context.InternetConnectionRequestStatuses.AddAsync(internetConnectionRequestStatusEntity);
        }
        else
        {
            throw new InvalidOperationException("The provided entity is not of type InternetConnectionRequestStatus.");
        }
    }

    public async Task UpdateAsync(int id, IInternetConnectionRequestStatus entity)
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