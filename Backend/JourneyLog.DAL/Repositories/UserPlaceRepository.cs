using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class UserPlaceRepository : BaseRepository<Guid, UserPlace>, IUserPlaceRepository
{
    public UserPlaceRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
    
    public async Task<UserPlace?> GetByUserIdAndPlaceIdAsync(Guid userId, string placeId)
    {
        return await _dbSet
            .Where(userPlace => userPlace.UserId == userId && userPlace.PlaceId == placeId)
            .FirstOrDefaultAsync();
    }
}