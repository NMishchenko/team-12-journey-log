using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class NotePhotoRepository : BaseRepository<Guid, NotePhoto>, INotePhotoRepository
{
    public NotePhotoRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}