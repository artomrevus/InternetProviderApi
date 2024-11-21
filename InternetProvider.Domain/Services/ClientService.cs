using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Domain.Mappers;
using InternetProvider.Domain.Interfaces.Services;
using InternetProvider.GeneralTypes.Sort;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;

namespace InternetProvider.Domain.Services;

public class ClientService(IUnitOfWork unitOfWork) : IClientService
{
    public async Task<ClientOutput> GetByIdAsync(int id)
    {
        var repositoryEntity = await unitOfWork.Clients.GetByIdAsync(id);
        return repositoryEntity.ToDomainClientOutput();
    }

    public async Task<IEnumerable<ClientOutput>> GetAllAsync()
    {
        var repositoryEntities = await unitOfWork.Clients.GetAllAsync();
        return repositoryEntities.Select(x => x.ToDomainClientOutput());
    }

    public async Task AddAsync(ClientInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureClient();
        repositoryEntity.RegistrationDate = DateOnly.FromDateTime(DateTime.UtcNow);
        repositoryEntity.CreateDateTime = DateTime.UtcNow;
        await unitOfWork.Clients.AddAsync(repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, ClientInput entity)
    {
        var repositoryEntity = entity.ToInfrastructureClient();
        repositoryEntity.UpdateDateTime = DateTime.UtcNow;
        await unitOfWork.Clients.UpdateAsync(id, repositoryEntity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Clients.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }

    public async Task<int> GetIdByUserIdAsync(string userId)
    {
        return await unitOfWork.Clients.GetIdByUserIdAsync(userId);
    }

    public async Task<IEnumerable<ClientOutput>> GetAsync(
        Dictionary<string, object>? filter, 
        Dictionary<string, SortType>? sort, 
        int? pageNumber,
        int? pageSize)
    {
        var repositoryEntities = await unitOfWork.Clients.GetAsync(filter, sort, pageNumber, pageSize);
        return repositoryEntities.Select(x => x.ToDomainClientOutput());
    }

    public async Task<int> CountAsync(Dictionary<string, object>? filter)
    {
        return await unitOfWork.Clients.CountAsync(filter);
    }
}