using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class InternetTariffService(IUnitOfWork unitOfWork) : IInternetTariffService
{
    public async Task<IInternetTariff> GetByIdAsync(int id)
    {
        return await unitOfWork.InternetTariffs.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IInternetTariff>> GetAllAsync()
    {
        return await unitOfWork.InternetTariffs.GetAllAsync();
    }

    public async Task AddAsync(IInternetTariff entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetTariffs.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IInternetTariff entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.InternetTariffs.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.InternetTariffs.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}