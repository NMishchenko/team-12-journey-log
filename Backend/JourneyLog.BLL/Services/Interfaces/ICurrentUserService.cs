using JourneyLog.DAL.Entities;

namespace JourneyLog.BLL.Services.Interfaces;

public interface ICurrentUserService
{
    Task<User> GetCurrentUserAsync();
}