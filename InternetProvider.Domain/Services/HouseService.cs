using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class HouseService(IUnitOfWork unitOfWork) : IHouseService
{
    public async Task<IHouse> GetByIdAsync(int id)
    {
        return await unitOfWork.Houses.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IHouse>> GetAllAsync()
    {
        return await unitOfWork.Houses.GetAllAsync();
    }

    public async Task AddAsync(IHouse entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Houses.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IHouse entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Houses.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Houses.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}