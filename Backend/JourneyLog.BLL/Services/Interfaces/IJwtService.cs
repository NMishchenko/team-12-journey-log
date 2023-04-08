using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JourneyLog.DAL.Entities;
using Microsoft.IdentityModel.Tokens;

namespace JourneyLog.BLL.Services.Interfaces;

public interface IJwtService
{
    SigningCredentials GetSigningCredentials();
    Task<List<Claim>> GetClaimsAsync(User user);
    JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
}