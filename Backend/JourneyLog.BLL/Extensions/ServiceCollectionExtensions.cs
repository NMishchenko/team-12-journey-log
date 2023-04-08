﻿using AutoMapper;
using JourneyLog.BLL.MappingProfiles;
using JourneyLog.BLL.Services;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyLog.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddValidators(services);
        AddServices(services);

        return services;
    }
    
    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AuthProfile));
    }
    
    private static void AddServices(IServiceCollection services)
    {
        // Add services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IEmailService, EmailService>();
    }

    private static void AddValidators(IServiceCollection services)
    {
        // Add validators
    }
}