using JourneyLog.BLL.Models.Auth;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JourneyLog.PL.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await _authService.LoginAsync(loginModel);
        return Ok(token);
    }

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Signup(SignupModel signupModel)
    {
        await _authService.SignupAsync(signupModel);
        return Ok();
    }
    
    [HttpGet("confirmEmail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConfirmEmail([FromQuery]ConfirmEmailModel confirmEmailModel)
    {
        await _authService.ConfirmEmailAsync(confirmEmailModel);
        return Ok();
    }

    [HttpGet("sendEmailConfirmationLink")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SendEmailConfirmation([FromQuery]string email)
    {
        await _authService.SendEmailConfirmationLink(email);
        return NoContent();
    }
    
    [HttpPut("forgotPassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
    {
        await _authService.ForgotPasswordAsync(forgotPasswordModel);
        return Ok();
    }

    [HttpPut("resetPassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
    {
        await _authService.ResetPasswordAsync(resetPasswordModel);
        return Ok();
    }
}