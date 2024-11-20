namespace InternetProvider.Infrastructure.Interfaces.Repositories;

public interface IGetIdByUserIdRepository<T>
{
    Task<int> GetIdByUserIdAsync(string userId);
}