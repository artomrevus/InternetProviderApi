namespace InternetProvider.Domain.Interfaces.Services;

public interface IGetIdByUserIdService<T>
{
    Task<int> GetIdByUserIdAsync(string userId);
}