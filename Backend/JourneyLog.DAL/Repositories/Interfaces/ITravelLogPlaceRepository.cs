using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface ITravelLogPlaceRepository : IRepository<Guid, TravelLogPlace>
{
    Task<TravelLogPlace?> GetByTravelLogIdAndPlaceIdWithTravelLogAsync(Guid travelLogId, string placeId);
}