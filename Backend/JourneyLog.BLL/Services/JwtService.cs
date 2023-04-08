using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JourneyLog.BLL.Models.Auth;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JourneyLog.BLL.Services;

public class JwtService: IJwtService
{
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<User> _userManager;
        
    public JwtService(
        IOptions<JwtSettings> jwtSettings,
        UserManager<User> userManager)
    {
        _jwtSettings = jwtSettings.Value;
        _userManager = userManager;
    }
        
    public SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<List<Claim>> GetClaimsAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        claims.AddRange(userRoles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

        return claims;
    }
        
    public JwtSecurityToken GenerateToken(SigningCredentials signingCredentials,
        IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: signingCredentials);

        return token;
    }
}