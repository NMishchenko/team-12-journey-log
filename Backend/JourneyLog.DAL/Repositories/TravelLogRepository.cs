using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class TravelLogRepository : BaseRepository<Guid, TravelLog>, ITravelLogRepository
{
    public TravelLogRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }

    public async Task<IEnumerable<TravelLog>> GetAllByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Where(travelLog => travelLog.UserId == userId)
            .ToListAsync();
    }

    public async Task<TravelLog?> GetWithAllNestedPropertiesAsync(Guid id)
    {
        return await _dbSet
            .Include(travelLog => travelLog.TravelLogPlaces)
            .ThenInclude(placeTravelLogs => placeTravelLogs.TravelNote)
            .ThenInclude(note => note.NotePhotos)
            .FirstOrDefaultAsync(travelLog => travelLog.Id == id);
    }
}