namespace InternetProvider.Application.Interfaces.Services;

public interface IAccessCheckService<TRequest>
{
    public Task<bool> HasUserAccess(int accessedId, string userId);
}