using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;

namespace InternetProvider.Domain.Services;

public class LocationTypeService(IUnitOfWork unitOfWork) : ILocationTypeService
{
    public async Task<ILocationType> GetByIdAsync(int id)
    {
        return await unitOfWork.LocationTypes.GetByIdAsync(id);
    }

    public async Task<IEnumerable<ILocationType>> GetAllAsync()
    {
        return await unitOfWork.LocationTypes.GetAllAsync();
    }

    public async Task AddAsync(ILocationType entity)
    {
        entity.CreateDateTime = DateTime.UtcNow;
        
        await unitOfWork.LocationTypes.AddAsync(entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task UpdateAsync(int id, ILocationType entity)
    {
        entity.UpdateDateTime = DateTime.UtcNow;
        
        await unitOfWork.LocationTypes.UpdateAsync(id, entity);
        await unitOfWork.CompleteAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await unitOfWork.LocationTypes.DeleteAsync(id);
        await unitOfWork.CompleteAsync();
    }
}