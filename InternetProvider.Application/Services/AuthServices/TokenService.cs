using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InternetProvider.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InternetProvider.Application.Services.AuthServices;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public string CreateJwtToken(IdentityUser user, IList<string> roles)
    {
        // Claims:
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Identity user username is null")),
            new Claim("id", user.Id),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        // Credentials:
        var configurationJwtKey = configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(configurationJwtKey))
        {
            throw new InvalidOperationException("Jwt:Key is not configured.");
        }
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationJwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Token:
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}