using Microsoft.AspNetCore.Identity;

namespace InternetProvider.API.Auth.Interfaces;

public interface ITokenService
{
    string CreateJwtToken(IdentityUser user, IList<string> role);
}