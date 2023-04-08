using JourneyLog.BLL.Models.Auth;

namespace JourneyLog.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<JwtModel> LoginAsync(LoginModel model);
    Task SignupAsync(SignupModel model);
}