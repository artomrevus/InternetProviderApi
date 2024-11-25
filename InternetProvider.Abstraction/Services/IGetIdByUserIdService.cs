namespace InternetProvider.Abstraction.Services;

public interface IGetIdByUserIdService<T>
{
    Task<int> GetIdByUserIdAsync(string userId);
}