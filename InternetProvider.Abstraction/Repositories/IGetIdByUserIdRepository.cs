namespace InternetProvider.Abstraction.Repositories;

public interface IGetIdByUserIdRepository<T>
{
    Task<int> GetIdByUserIdAsync(string userId);
}