using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyLog.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    const string JourneyLogDatabase = "JourneyLogDbConnection";
    
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddIdentity(services);
        AddRepositories(services);

        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JourneyLogContext>(
            options => options.UseSqlServer(configuration.GetConnectionString(JourneyLogDatabase)));
    }
    
    private static IServiceCollection AddIdentity(
        this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<JourneyLogContext>()
            .AddUserStore<UserStore<User, IdentityRole<Guid>, JourneyLogContext, Guid>>()
            .AddRoleStore<RoleStore<IdentityRole<Guid>, JourneyLogContext, Guid>>();

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        
    }
}