using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Abstraction.Services;
using InternetProvider.API.Auth.Interfaces;
using InternetProvider.API.DTOs.AuthDTOs;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InternetProvider.API.Auth.Auth;

public class ClientRegisterService(UserManager<IdentityUser> userManager, IClientService clientService, IUserMapper<IClient, RegisterClientRequestDto> mapper) : IClientRegisterService
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

        await clientService.AddAsync(mapper.ToEntity(entity, user.Id));
        var clientId = await clientService.GetIdByUserIdAsync(user.Id);
            
        return new RegisterClientResponseDto()
        {
            UserName = user.UserName,
            Role = RoleName,
            ClientId = clientId,
        };
    }
}