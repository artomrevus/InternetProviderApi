using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider.Infrastructure.Data;

public class AuthDbContext : IdentityDbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Creating roles:
        string adminRoleId = Guid.NewGuid().ToString();
        const string adminRoleName = "Admin";
        
        string clientRoleId = Guid.NewGuid().ToString();
        const string clientRoleName = "Client";
        
        string employeeRoleId = Guid.NewGuid().ToString();
        const string employeeRoleName = "Employee";

        var roles = new List<IdentityRole>
        {
            new ()
            {
                Id = adminRoleId,
                Name = adminRoleName,
                NormalizedName = adminRoleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new ()
            {
                Id = clientRoleId,
                Name = clientRoleName,
                NormalizedName = clientRoleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new ()
            {
                Id = employeeRoleId,
                Name = employeeRoleName,
                NormalizedName = employeeRoleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }
        };
        
        builder.Entity<IdentityRole>().HasData(roles);
        
        // Admin:
        string adminUserId = Guid.NewGuid().ToString();
        const string adminUserName = "artomrevus";
        const string adminEmail = "artomrevus@gmail.com";
        const string adminPassword = "InternetProviderAdmin";
        
        var admin = new IdentityUser
        {
            Id = adminUserId,
            UserName = adminUserName,
            Email = adminEmail,
            NormalizedUserName = adminUserName.ToUpper(),
            NormalizedEmail = adminEmail.ToUpper(),
        };
        
        admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, adminPassword);
        builder.Entity<IdentityUser>().HasData(admin);

        var adminRole = new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = adminRoleId,
        };
        
        builder.Entity<IdentityUserRole<string>>().HasData(adminRole);
    }
}