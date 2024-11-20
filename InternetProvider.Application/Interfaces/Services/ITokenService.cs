using Microsoft.AspNetCore.Identity;

namespace InternetProvider.Application.Interfaces.Services;

public interface ITokenService
{
    string CreateJwtToken(IdentityUser user, IList<string> role);
}