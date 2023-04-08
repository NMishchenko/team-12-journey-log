using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class TravelNoteRepository : BaseRepository<Guid, TravelNote>, ITravelNoteRepository
{
    public TravelNoteRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}