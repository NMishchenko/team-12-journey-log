using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Text;
using AutoMapper;
using JourneyLog.BLL.Exceptions;
using JourneyLog.BLL.Models.Auth;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace JourneyLog.BLL.Services;

public class AuthService: IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtHandler;

    public AuthService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IMapper mapper, 
        IJwtService jwtHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task SignupAsync(SignupModel model)
    {
        var user = _mapper.Map<User>(model);

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            throw new AuthException(result.ToString());
        }

        // Send email confirmation link
    }

    public async Task<JwtModel> LoginAsync(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            throw new AuthException("Invalid email or password");
        }

        var result = await _signInManager
            .PasswordSignInAsync(user, model.Password, false, false);

        if (!result.Succeeded)
        {
            throw new InvalidCredentialException("Invalid email or password");
        }

        var claims = await _jwtHandler.GetClaimsAsync(user);
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var token = _jwtHandler.GenerateToken(signingCredentials, claims);

        return new JwtModel()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };
    }
}