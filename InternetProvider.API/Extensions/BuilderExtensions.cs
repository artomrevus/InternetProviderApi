using System.Text;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Application.Services.AuthServices;
using InternetProvider.Application.Services.CrudServices;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InternetProvider.API.Extensions;

public static class BuilderExtensions
{
    public static void AddDbContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InternetProviderContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("InternetProviderDbSqlServer"));
        });

        builder.Services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("InternetProviderDbSqlServer"));
        });
    }
    
    public static void AddRepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddDomainServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<Domain.Interfaces.Services.ICityService, Domain.Services.CityService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.IClientService, Domain.Services.ClientService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.IClientStatusService, Domain.Services.ClientStatusService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.IHouseService, Domain.Services.HouseService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.ILocationService, Domain.Services.LocationService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.ILocationTypeService, Domain.Services.LocationTypeService>();
        builder.Services.AddScoped<Domain.Interfaces.Services.IStreetService, Domain.Services.StreetService>();
    }
    
    public static void AddApplicationCrudServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IClientStatusService, ClientStatusService>();
        builder.Services.AddScoped<IHouseService, HouseService>();
        builder.Services.AddScoped<ILocationService, LocationService>();
        builder.Services.AddScoped<ILocationTypeService, LocationTypeService>();
        builder.Services.AddScoped<IStreetService, StreetService>();
    }
    
    public static void AddApplicationAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientRegisterService, ClientRegisterService>();
        builder.Services.AddScoped<IClientLoginService, ClientLoginService>();
        builder.Services.AddScoped<IAdminLoginService, AdminLoginService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
    }
    
    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("InternetProvider")
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 0;
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    AuthenticationType = "Jwt",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                };
            });
    }
}