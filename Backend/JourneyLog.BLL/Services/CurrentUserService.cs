using System.Security.Claims;
using JourneyLog.BLL.Exceptions.NotFound;
using JourneyLog.BLL.Services.Interfaces;
using JourneyLog.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace JourneyLog.BLL.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<User> GetCurrentUserAsync()
    {
        var currentUserName = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        var currentUser = await _userManager.FindByEmailAsync(currentUserName);
        
        if (currentUser is null)
        {
            throw new NotFoundException("Current user not found");
        }

        return currentUser;
    }
}