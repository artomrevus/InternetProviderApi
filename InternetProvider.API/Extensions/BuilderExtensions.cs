using System.Text;
using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Repositories;
using InternetProvider.Abstraction.Services;
using InternetProvider.API.Auth.Auth;
using InternetProvider.API.Auth.Interfaces;
using InternetProvider.API.DTOs.AuthDTOs;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;
using InternetProvider.API.Mappers.Mappers;
using InternetProvider.Domain.Services;
using InternetProvider.Infrastructure.Data;
using InternetProvider.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InternetProvider.API.Extensions;

public static class BuilderExtensions
{
    public static void AddSqlServerEntities(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICity, City>();
        builder.Services.AddScoped<IClient, Client>();
        builder.Services.AddScoped<IClientStatus, ClientStatus>();
        builder.Services.AddScoped<IHouse, House>();
        builder.Services.AddScoped<IInternetConnectionRequest, InternetConnectionRequest>();
        builder.Services.AddScoped<IInternetConnectionRequestStatus, InternetConnectionRequestStatus>();
        builder.Services.AddScoped<IInternetTariff, InternetTariff>();
        builder.Services.AddScoped<IInternetTariffStatus, InternetTariffStatus>();
        builder.Services.AddScoped<ILocation, Location>();
        builder.Services.AddScoped<ILocationType, LocationType>();
        builder.Services.AddScoped<IStreet, Street>();
    }
    
    public static void AddSqlServerDbContextServices(this WebApplicationBuilder builder)
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
    
    public static void AddSqlServerRepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    public static void AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMapper<ICity, CityRequestDto, CityResponseDto>, CityMapper>();
        builder.Services.AddScoped<IMapper<IClient, ClientRequestDto, ClientResponseDto>, ClientMapper>();
        builder.Services.AddScoped<IUserMapper<IClient, RegisterClientRequestDto>, ClientMapper>();
        builder.Services.AddScoped<IMapper<IClientStatus, ClientStatusRequestDto, ClientStatusResponseDto>, ClientStatusMapper>();
        builder.Services.AddScoped<IMapper<IHouse, HouseRequestDto, HouseResponseDto>, HouseMapper>();
        builder.Services.AddScoped<IMapper<IInternetConnectionRequest, InternetConnectionRequestRequestDto, InternetConnectionRequestResponseDto>, InternetConnectionRequestMapper>();
        builder.Services.AddScoped<IMapper<IInternetConnectionRequestStatus, InternetConnectionRequestStatusRequestDto, InternetConnectionRequestStatusResponseDto>, InternetConnectionRequestStatusMapper>();
        builder.Services.AddScoped<IMapper<IInternetTariff, InternetTariffRequestDto, InternetTariffResponseDto>, InternetTariffMapper>();
        builder.Services.AddScoped<IMapper<IInternetTariffStatus, InternetTariffStatusRequestDto, InternetTariffStatusResponseDto>, InternetTariffStatusMapper>();
        builder.Services.AddScoped<IMapper<ILocation, LocationRequestDto, LocationResponseDto>, LocationMapper>();
        builder.Services.AddScoped<IMapper<ILocationType, LocationTypeRequestDto, LocationTypeResponseDto>, LocationTypeMapper>();
        builder.Services.AddScoped<IMapper<IStreet, StreetRequestDto, StreetResponseDto>, StreetMapper>();
    }
    
    public static void AddCrudServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IClientStatusService, ClientStatusService>();
        builder.Services.AddScoped<IHouseService, HouseService>();
        builder.Services.AddScoped<ILocationService, LocationService>();
        builder.Services.AddScoped<ILocationTypeService, LocationTypeService>();
        builder.Services.AddScoped<IStreetService, StreetService>();
        builder.Services.AddScoped<IInternetTariffStatusService, InternetTariffStatusService>();
        builder.Services.AddScoped<IInternetConnectionRequestStatusService, InternetConnectionRequestStatusService>();
        builder.Services.AddScoped<IInternetTariffService, InternetTariffService>();
        builder.Services.AddScoped<IInternetConnectionRequestService, InternetConnectionRequestService>();
    }
    
    public static void AddAuthServices(this WebApplicationBuilder builder)
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