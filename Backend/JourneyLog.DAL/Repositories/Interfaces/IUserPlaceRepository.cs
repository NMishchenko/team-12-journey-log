using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface IUserPlaceRepository : IRepository<Guid, UserPlace>
{
    Task<UserPlace?> GetByUserIdAndPlaceIdAsync(Guid userId, string placeId);
}