using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyLog.DAL.Extensions;

public static class ServiceCollectionExtensions
{
    const string JourneyLogDatabase = "JourneyLog";
    
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
    
    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IPlaceTravelLogRepository, PlaceTravelLogRepository>();
        services.AddScoped<ITravelLogRepository, TravelLogRepository>();
        services.AddScoped<ITravelNoteRepository, TravelNoteRepository>();
        services.AddScoped<ITravelNoteRepository, TravelNoteRepository>();
        services.AddScoped<ITravelPhotoRepository, TravelPhotoRepository>();
        services.AddScoped<IUserPlaceRepository, UserPlaceRepository>();
    }
}