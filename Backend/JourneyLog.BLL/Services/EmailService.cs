using Flurl.Http;
using JourneyLog.BLL.Models.Email;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace JourneyLog.BLL.Services;

public class EmailService: IEmailService
{
    private readonly IConfiguration _configuration;
        
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
        
    public async Task SendEmailConfirmationLinkAsync(string to, string link)
    {
        var subject = "Email confirmation on Journey Log website";
        var body = "Hello! You've signed up on Journey Log website. " +
                   $"Click here to confirm your account: {link}. " +
                   "Please ignore this email if it wasn't you.";
            
        var url = _configuration.GetConnectionString("LOGICAL_APP_URL");

        var emailModel = new SendEmailModel
        {
            To = to,
            Subject = subject,
            Body = body
        };

        _ = await url
            .PostJsonAsync(emailModel);
    }

    public async Task SendResetPasswordLinkAsync(string to, string callback)
    {
        var subject = "Password Recovery on Journey Log website";
        var body =
            $"Hello! Click this link to reset your password on Journey Log website: {callback}. " +
            "Please ignore this email if it wasn't you.";
            
        var url = _configuration.GetConnectionString("LOGICAL_APP_URL");

        var emailModel = new SendEmailModel
        {
            To = to,
            Subject = subject,
            Body = body
        };
            
        _ = await url
            .PostJsonAsync(emailModel);
    }
}