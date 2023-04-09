using System.Text;
using FluentValidation;
using JourneyLog.BLL.Models.Auth;
using JourneyLog.BLL.Models.Place;
using JourneyLog.BLL.Models.TravelLog;
using JourneyLog.BLL.Models.TravelLogPlaceNote;
using JourneyLog.BLL.Models.TravelLogPlaceNotePhotos;
using JourneyLog.BLL.Validators.Auth;
using JourneyLog.BLL.Validators.Note;
using JourneyLog.BLL.Validators.NotePhotos;
using JourneyLog.BLL.Validators.Place;
using JourneyLog.BLL.Validators.TravelLog;
using JourneyLog.BLL.Validators.TravelLogPlace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace JourneyLog.PL.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwagger();
        services.AddOptions(configuration);
        services.AddAuth(configuration);

        return services;
    }
    
    private static void AddOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
    }

    private static void AddValidators(IServiceCollection services)
    {
        services.AddScoped<IValidator<SignupModel>, SignupModelValidator>();
        
        services.AddScoped<IValidator<CreateUpdateNoteModel>, CreateUpdateNoteModelValidator>();
        
        services.AddScoped<IValidator<CreateNotePhotoModel>, CreateNotePhotoModelValidator>();

        services.AddScoped<IValidator<CreateUpdatePlaceRating>, CreateUpdatePlaceRatingModelValidator>();
        services.AddScoped<IValidator<CreateUpdatePlaceReview>, CreateUpdatePlaceReviewModelValidator>();
        services.AddScoped<IValidator<GetPlaceByBBoxModel>, GetPlaceByBBoxModelValidator>();
        services.AddScoped<IValidator<GetPlaceByRadiusModel>, GetPlaceByRadiusModelValidator>();

        services.AddScoped<IValidator<CreateTravelLogModel>, CreateTravelLogModelValidator>();
        services.AddScoped<IValidator<UpdateTravelLogModel>, UpdateTravelLogModelValidator>();
        services.AddScoped<IValidator<UpdateTravelLogPlaceInfoModel>, UpdateTravelLogPlaceModelValidator>();

    }


    private static void AddAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthorization();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration.GetSection("JwtSettings")["Issuer"],
                    ValidAudience = configuration.GetSection("JwtSettings")["Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings")["Key"]))
                };
            });
    }
    
    

    private static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "JourneyLog API"});
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });
        });
    }
}