using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.Domain.Mappers;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class InternetTariffService(IUnitOfWork unitOfWork) : IInternetTariffService
{
    public async Task<InternetTariffOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.InternetTariffs.GetByIdAsync(id);
        return repositoryEntity.ToDomainInternetTariffOutput();
    }

    public async Task<IEnumerable<InternetTariffOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.InternetTariffs.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainInternetTariffOutput());
    }

    public async Task AddAsync(InternetTariffInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetTariff();
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetTariffs.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, InternetTariffInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureInternetTariff();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        await unitOfWork.InternetTariffs.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetTariffs.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}