using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Domain.Mappers;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class InternetTariffStatusService(IUnitOfWork unitOfWork) : IInternetTariffStatusService
{
    public async Task<InternetTariffStatusOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.InternetTariffStatuses.GetByIdAsync(id);
        return repositoryEntity.ToDomainInternetTariffStatusOutput();
    }

    public async Task<IEnumerable<InternetTariffStatusOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.InternetTariffStatuses.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainInternetTariffStatusOutput());
    }

    public async Task AddAsync(InternetTariffStatusInput entity)
    {
        var entities = await unitOfWork.InternetTariffStatuses.GetAllAsync();
        var entitiesList = entities.ToList();
        
        var lastEntityId = entitiesList.Count != 0 ? entitiesList.Last().InternetTariffStatusId : 0;
        
        var repositoryEntity = entity.ToInfrastructureInternetTariffStatus();
        repositoryEntity.InternetTariffStatusId = lastEntityId + 1;
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetTariffStatuses.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, InternetTariffStatusInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetTariffStatus();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetTariffStatuses.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetTariffStatuses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}