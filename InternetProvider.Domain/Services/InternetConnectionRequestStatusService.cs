using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Domain.Mappers;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class InternetConnectionRequestStatusService(IUnitOfWork unitOfWork) : IInternetConnectionRequestStatusService
{
    public async Task<InternetConnectionRequestStatusOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.InternetConnectionRequestStatuses.GetByIdAsync(id);
        return repositoryEntity.ToDomainInternetConnectionRequestStatusOutput();
    }

    public async Task<IEnumerable<InternetConnectionRequestStatusOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.InternetConnectionRequestStatuses.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainInternetConnectionRequestStatusOutput());
    }

    public async Task AddAsync(InternetConnectionRequestStatusInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetConnectionRequestStatus();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetConnectionRequestStatuses.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, InternetConnectionRequestStatusInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetConnectionRequestStatus();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetConnectionRequestStatuses.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetConnectionRequestStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}