using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class TravelLogPlaceRepository : BaseRepository<Guid, TravelLogPlace>, ITravelLogPlaceRepository
{
    public TravelLogPlaceRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }

    public async Task<TravelLogPlace?> GetByTravelLogIdAndPlaceIdWithTravelLogAsync(Guid travelLogId, string placeId)
    {
        return await _dbSet
            .Include(travelLogPlace => travelLogPlace.TravelLog)
            .Where(travelLogPlace => travelLogPlace.TravelLogId == travelLogId && travelLogPlace.PlaceId == placeId)
            .FirstOrDefaultAsync();
    }
}