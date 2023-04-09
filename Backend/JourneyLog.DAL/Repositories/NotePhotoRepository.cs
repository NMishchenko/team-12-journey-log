using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JourneyLog.DAL.Repositories;

public class NotePhotoRepository : BaseRepository<Guid, NotePhoto>, INotePhotoRepository
{
    public NotePhotoRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
    
    public async Task<NotePhoto?> GetByIdWithTravelLogAsync(Guid id)
    {
        return await _dbSet
            .Include(notePhoto => notePhoto.TravelNote)
            .ThenInclude(travelNote => travelNote.TravelLogPlace)
            .ThenInclude(travelLogPlace => travelLogPlace.TravelLog)
            .FirstOrDefaultAsync(notePhoto => notePhoto.Id == id);
    }
}