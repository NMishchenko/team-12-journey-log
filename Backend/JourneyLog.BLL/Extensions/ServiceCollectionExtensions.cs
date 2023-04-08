using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyLog.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        AddMapper(services);
        AddValidators(services);
        AddServices(services);

        return services;
    }
    
    private static void AddMapper(IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            // Add mapping profiles
        });

        services.AddSingleton(mappingConfig.CreateMapper());
    }
    
    private static void AddServices(IServiceCollection services)
    {
        // Add services
    }

    private static void AddValidators(IServiceCollection services)
    {
        // Add validators
    }
}