using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Abstraction.Services;
using InternetProvider.API.Auth.Interfaces;
using InternetProvider.API.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.API.Auth.Auth;

public class ClientLoginService(UserManager<IdentityUser> userManager, ITokenService tokenService, IClientService clientService) : IClientLoginService
{
    private const string RoleName = "Client";
    
    public async Task<LoginClientResponseDto> LoginAsync(LoginClientRequestDto entity)
    {
        var identityUser = await userManager.FindByNameAsync(entity.UserName);
        if (identityUser is null)
        {
            throw new AccessException("Invalid username.");
        }
            
        var checkResult = await userManager.CheckPasswordAsync(identityUser, entity.Password);
        if (!checkResult)
        {
            throw new AccessException("Invalid password.");
        }

        var userRoles = await GetUserRolesAsync(identityUser);
        var jwtToken = tokenService.CreateJwtToken(identityUser, userRoles);
        var clientId = await clientService.GetIdByUserIdAsync(identityUser.Id);
            
        return new LoginClientResponseDto
        {
            UserName = entity.UserName,
            Role = RoleName,
            Token = jwtToken,
            ClientId = clientId,
        };
    }

    private async Task<IList<string>> GetUserRolesAsync(IdentityUser identityUser)
    {
        var userRoles = await userManager.GetRolesAsync(identityUser);
        if (userRoles is null || !userRoles.Any())
        {
            throw new AccessException($"No role assigned to user with username \"{identityUser.UserName}\".");
        }
        if (!userRoles.Contains(RoleName))
        {
            throw new AccessException($"Invalid role selected. User with this username and password has the roles: {string.Join(", ", userRoles)}.");
        }
        
        return userRoles;
    }
}