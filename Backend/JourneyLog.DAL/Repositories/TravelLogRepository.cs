using JourneyLog.DAL.Entities;
using JourneyLog.DAL.Repositories.Interfaces;

namespace JourneyLog.DAL.Repositories;

public class TravelLogRepository : BaseRepository<Guid, TravelLog>, ITravelLogRepository
{
    public TravelLogRepository(JourneyLogContext journeyLogContext) : base(journeyLogContext)
    {
    }
}