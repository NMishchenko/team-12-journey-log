using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class TravelNoteRepository : BaseRepository<Guid, TravelNote>, ITravelNoteRepository
{
    public TravelNoteRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
    
    public async Task<TravelNote?> GetByTravelLogIdAndPlaceIdWithTravelLogAsync(Guid travelLogId, string placeId)
    {
        return await _dbSet
            .Include(travelNote => travelNote.TravelLogPlace)
            .ThenInclude(travelLogPlace => travelLogPlace.TravelLog)
            .FirstOrDefaultAsync(travelNote => travelNote.TravelLogPlace.TravelLogId == travelLogId && travelNote.TravelLogPlace.PlaceId == placeId);
    }

    public async Task<TravelNote?> GetByIdWithTravelLogAsync(Guid noteId)
    {
        return await _dbSet
            .Include(travelNote => travelNote.TravelLogPlace)
            .ThenInclude(travelLogPlace => travelLogPlace.TravelLog)
            .FirstOrDefaultAsync(travelNote => travelNote.Id == noteId);
    }
}