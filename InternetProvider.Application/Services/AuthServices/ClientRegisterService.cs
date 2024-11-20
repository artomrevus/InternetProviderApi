using InternetProvider.Application.DTOs.AuthDTOs;
using InternetProvider.Application.Exception;
using InternetProvider.Application.Mappers;
using InternetProvider.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.Application.Services.AuthServices;

public class ClientRegisterService(UserManager<IdentityUser> userManager, Domain.Interfaces.Services.IClientService domainClientService) : IClientRegisterService
{
    private const string RoleName = "Client";
    
    public async Task<RegisterClientResponseDto> RegisterAsync(RegisterClientRequestDto entity)
    {
        var user = new IdentityUser
        {
            UserName = entity.UserName,
        };
            
        var identityResult = await userManager.CreateAsync(user, entity.Password);
        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            throw new AccessException($"Failed to create user. Errors: {errors}");
        }
        
        identityResult = await userManager.AddToRoleAsync(user, RoleName);
        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            throw new AccessException($"Failed to add user role. Errors: {errors}");
        }

        await domainClientService.AddAsync(entity.ToDomainClientInput(user.Id));
        var clientId = await domainClientService.GetIdByUserIdAsync(user.Id);
            
        return new RegisterClientResponseDto()
        {
            UserName = user.UserName,
            Role = RoleName,
            ClientId = clientId,
        };
    }
}