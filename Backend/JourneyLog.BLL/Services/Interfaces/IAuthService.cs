using JourneyLog.BLL.Models.Auth;

namespace JourneyLog.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<JwtModel> LoginAsync(LoginModel model);
    Task SignupAsync(SignupModel model);
    Task SendEmailConfirmationLink(string email);
    Task ConfirmEmailAsync(ConfirmEmailModel model);
    Task ForgotPasswordAsync(ForgotPasswordModel model);
    Task ResetPasswordAsync(ResetPasswordModel model);
}