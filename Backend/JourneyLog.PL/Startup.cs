using JourneyLog.BLL.Extensions;
using JourneyLog.DAL.Extensions;
using JourneyLog.PL.Extensions;
using JourneyLog.PL.Midlleware;

namespace JourneyLog.PL;

public class Startup
{
    const string FrontOriginPolicyName = "JourneyLogFrontend";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
            .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

        services.AddCors(options =>
        {
            options.AddPolicy(FrontOriginPolicyName, policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });       
        });

        services.AddPresentationLayer(Configuration);
        services.AddBusinessLogicLayer();
        services.AddDataAccessLayer(Configuration);
                
        services.AddEndpointsApiExplorer();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseExceptionHandlingMiddleware();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(FrontOriginPolicyName);

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseRouting();

        app.MapControllers();
    }
}