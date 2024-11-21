using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Domain.Mappers;
using InternetProvider.GeneralTypes.Sort;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class InternetConnectionRequestService(IUnitOfWork unitOfWork) : IInternetConnectionRequestService
{
    public async Task<InternetConnectionRequestOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.InternetConnectionRequests.GetByIdAsync(id);
        return repositoryEntity.ToDomainInternetConnectionRequestOutput();
    }

    public async Task<IEnumerable<InternetConnectionRequestOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.InternetConnectionRequests.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainInternetConnectionRequestOutput());
    }

    public async Task AddAsync(InternetConnectionRequestInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetConnectionRequest();
        repositoryEntity.RequestDate = DateOnly.FromDateTime(DateTime.UtcNow);
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetConnectionRequests.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, InternetConnectionRequestInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetConnectionRequest();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetConnectionRequests.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetConnectionRequests.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<InternetConnectionRequestOutput>> GetAsync(Dictionary<string, object>? filter, Dictionary<string, SortType>? sort, int? pageNumber, int? pageSize)
    {
        var repositoryEntities = await unitOfWork.InternetConnectionRequests.GetAsync(filter, sort, pageNumber, pageSize);
        return repositoryEntities.Select(x => x.ToDomainInternetConnectionRequestOutput());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.InternetConnectionRequests.CountAsync(filter);
    }
}