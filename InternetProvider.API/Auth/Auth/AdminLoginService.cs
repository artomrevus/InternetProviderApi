using InternetProvider.Abstraction.Exceptions;
using InternetProvider.API.Auth.Interfaces;
using InternetProvider.API.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.API.Auth.Auth;

public class AdminLoginService(UserManager<IdentityUser> userManager, ITokenService tokenService) : IAdminLoginService
{
    private const string RoleName = "Admin";
    
    public async Task<LoginAdminResponseDto> LoginAsync(LoginAdminRequestDto entity)
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
            
        return new LoginAdminResponseDto
        {
            UserName = entity.UserName,
            Role = RoleName,
            Token = jwtToken,
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
            throw new AccessException($"Invalid role selected. User with this username and password has the role: {string.Join(", ", userRoles)}.");
        }
        
        return userRoles;
    }
}