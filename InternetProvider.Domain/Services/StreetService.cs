using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class StreetService(IUnitOfWork unitOfWork) : IStreetService
{
    public async Task<IStreet> GetByIdAsync(int id)
    {
        return await unitOfWork.Streets.GetByIdAsync(id);
    }

    public async Task<IEnumerable<IStreet>> GetAllAsync()
    {
        return await unitOfWork.Streets.GetAllAsync();
    }

    public async Task AddAsync(IStreet entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Streets.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, IStreet entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.Streets.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.Streets.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}