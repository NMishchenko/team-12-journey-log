using JourneyLog.DAL.Entities;

namespace JourneyLog.DAL.Repositories.Interfaces;

public interface ITravelNoteRepository : IRepository<Guid, TravelNote>
{
    Task<TravelNote?> GetByTravelLogIdAndPlaceIdWithTravelLogAsync(Guid travelLogId, string placeId);
    Task<TravelNote?> GetByIdWithTravelLogAsync(Guid noteId);
}