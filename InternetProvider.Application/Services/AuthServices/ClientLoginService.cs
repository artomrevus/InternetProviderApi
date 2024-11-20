using InternetProvider.Application.DTOs.AuthDTOs;
using InternetProvider.Application.Exception;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Domain.Entities;
using InternetProvider.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace InternetProvider.Application.Services.AuthServices;

public class ClientLoginService(UserManager<IdentityUser> userManager, ITokenService tokenService, Domain.Interfaces.Services.IClientService domainClientService) : IClientLoginService
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
        var clientId = await domainClientService.GetIdByUserIdAsync(identityUser.Id);
            
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
        if (userRoles.IsNullOrEmpty())
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