namespace InternetProvider.Abstraction.Services;

public interface IAccessCheckService<TRequest>
{
    public Task<bool> HasUserAccess(int accessedId, string userId);
}